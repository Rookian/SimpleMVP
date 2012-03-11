using Core;
using NHibernate;

namespace Infrastructure
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ISession session) : base(session)
        {
        }
    }
}