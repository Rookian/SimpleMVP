using Core.DomainModels;
using FluentNHibernate.Mapping;

namespace Infrastructure.Mappings
{
    public class ArticleMapping : ClassMap<Article>
    {
        public ArticleMapping()
        {
            Id(x => x.ArticleId).Column("ArticleId").GeneratedBy.Identity();
            Map(x => x.Description).Column("Description").UniqueKey("Article_Description_Unique");
        }
    }
}