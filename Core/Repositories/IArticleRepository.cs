using Core.DomainModels;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetByDescription(string Description);
    }
}