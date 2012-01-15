using System.Collections.Generic;

namespace SimpleMvp
{
    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<string> GetAll()
        {
            yield return "foo";
            yield return "bar";
            yield return "baz";
        }
    }
}