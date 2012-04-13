using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Mappings;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;


namespace Infrastructure.Nhibernate
{
    public class ConfigurationFactory
    {
        const string Database = "Ariha";
        const string Server = @"localhost";

        public static Configuration Build()
        {           
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c.Database(Database).TrustedConnection().Server(Server)))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<ArticleMapping>();
                    m.HbmMappings.AddFromAssemblyOf<ArticleMapping>();
                })
                //.ExposeConfiguration(c => new SchemaExport(c).Execute(true, true, false))
                .BuildConfiguration();
        }
    }
}