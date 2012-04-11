using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Mappings;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace Infrastructure.Nhibernate
{
    public class ConfigurationFactory
    {
        const string Database = "Ariha";
        const string Server = @"localhost\sqlexpress";

        public Configuration Build()
        {
            var config = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.Database(Database).TrustedConnection().Server(Server)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ArticleMapping>())
                //.ExposeConfiguration(x => new SchemaExport(x).Execute(true, true, false))
                
                .BuildConfiguration();

            return config;
        }
    }
}