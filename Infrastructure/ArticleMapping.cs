using Core;
using FluentNHibernate.Mapping;

namespace Infrastructure
{
    public class ArticleMapping : ClassMap<Article>
    {
        public ArticleMapping()
        {
            Id(x => x.Id).Column("ArticleId").GeneratedBy.Identity();
            Map(x => x.Name).Column("Description");
        }
    }
}