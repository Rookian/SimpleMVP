using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Mappings;
using NHibernate.Cfg;

namespace Infrastructure.Nhibernate
{
    public class ConfigurationFactory
    {
        const string Database = "Ariha";
        const string Server = @"localhost\sqlexpress";

        public Configuration Build()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.Database(Database).TrustedConnection().Server(Server)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ArticleMapping>())
                .BuildConfiguration();
        }
    }
}