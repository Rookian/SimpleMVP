using System.Collections.Generic;

namespace SimpleMvp
{
  internal class ArticleRepository : IArticleRepository
  {
    public IEnumerable<string> GetAll()
    {
      yield return "foo";
      yield return "bar";
      yield return "baz";
    }
  }
}