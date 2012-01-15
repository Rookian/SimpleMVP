using System.Collections.Generic;

namespace SimpleMvp
{
    public interface IArticleRepository
    {
        IEnumerable<string> GetAll();
    }
}