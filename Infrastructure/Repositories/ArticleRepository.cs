using Core.DomainModels;
using Core.Repositories;
using NHibernate;

namespace Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ISession session) : base(session)
        {
        }
    }
}