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

        public IEnumerable<Article> GetByDescription(string description)
        {
            return _session
                .GetNamedQuery("ArticlesByDescription")
                .SetString("Description", description)
                .List<Article>();
        }
    }
}