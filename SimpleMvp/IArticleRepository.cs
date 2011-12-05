using System.Collections.Generic;

namespace SimpleMvp
{
  internal interface IArticleRepository
  {
    IEnumerable<string> GetAll();
  }
}