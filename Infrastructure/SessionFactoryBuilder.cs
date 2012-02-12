using NHibernate;
using NHibernate.Cfg;

namespace Infrastructure
{
    public class SessionFactoryBuilder : ISessionFactoryBuilder
    {
        private const string SessionFactoryKey = "sessionFactory";

        private readonly SingletonInstanceScoper<ISessionFactory> _sessionFactorySingleton =
            new SingletonInstanceScoper<ISessionFactory>();


        public ISessionFactory GetFactory()
        {
            return _sessionFactorySingleton.GetScopedInstance(SessionFactoryKey, BuildFactory);
        }

        private static ISessionFactory BuildFactory()
        {
            Configuration cfg = new ConfigurationFactory().Build();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory;
        }
    }
}