using Core.DomainModels;
using Core.Repositories;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Transform;
using System;
using System.Collections;

namespace Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private ISession _session;

        public ArticleRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public List<Article> GetByDescription(string description)
        {
            return _session
                .InvokeStoredProcedure("ArticlesByDescription '" + description + "'")
                .SetResultTransformer(new Transformer(typeof(Article)))
                .List<Article>().ToList();
        }
    }

    public static class SessionExtension
    {
        public static ISQLQuery InvokeStoredProcedure(this ISession session, string storedProcedure)
        {
            var query = session.CreateSQLQuery(string.Format("EXEC {0}", storedProcedure));
            var str = query.QueryString;
            return query;
        }
    }

    public class  Transformer : IResultTransformer
    {
        AliasToEntityMapResultTransformer ate;
        public Transformer(Type type)
        {
            ate = new AliasToEntityMapResultTransformer();
        }

        public IList TransformList(IList collection)
        {
            var result = ate.TransformList(collection);
            return null;
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
            var result = ate.TransformTuple(tuple, aliases);
            return null;
        }
    }
}