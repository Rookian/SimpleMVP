using System;
using Infrastructure.Nhibernate;
using NHibernate;
using SimpleMvp.Infrastructure;
using SimpleMvp.Infrastructure.Bases;
using StructureMap;

namespace CompositionRoot
{
    public static class BootsTrapper
    {
         public static void Boot()
         {
             var buildSessionFactory = new ConfigurationFactory().Build().BuildSessionFactory();
             
             ObjectFactory.ResetDefaults();
             ObjectFactory.Initialize(x =>
             {
                 x.Scan(s =>
                 {
                     s.AssembliesFromApplicationBaseDirectory();
                     s.WithDefaultConventions();
                     s.ConnectImplementationsToTypesClosing(typeof(IPresenter<>));
                 });

                 x.For(typeof(IPresenterFactory<>)).Use(typeof(PresenterFactory<>));

                 x.For<ISession>().Use(buildSessionFactory.OpenSession);

                 // Get internal Presenter Factory with Ctor Parameter
                 x.For<Func<Type, object, IPresenter<IView>>>().Use(
                     (type, param) => (IPresenter<IView>)ObjectFactory
                                                              .With(param.GetType(), param)
                                                              .GetInstance(type));
                 // Get internal Presenter Factory without Ctor Parameter
                 x.For<Func<Type, IPresenter<IView>>>().Use(
                     type => (IPresenter<IView>)ObjectFactory.GetInstance(type));
             });
         }
    }
}