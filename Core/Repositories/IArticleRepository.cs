using Core.DomainModels;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetByDescription(string Description);
    }
}