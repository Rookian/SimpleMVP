using Core.Domain;
using Core.Repository;
using NHibernate;

namespace Infrastructure.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ISession session) : base(session)
        {
        }
    }
}