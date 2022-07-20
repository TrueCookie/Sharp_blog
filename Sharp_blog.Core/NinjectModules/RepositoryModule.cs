using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Sharp_blog.Core.Objects;

namespace Sharp_blog.Core.NinjectModules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISessionFactory>()
                .ToMethod
                (
                    context => Fluently.Configure()
                        .Database(PostgreSQLConfiguration.Standard
                            .ConnectionString(csb => csb.FromConnectionStringWithKey("Sharp_blog"))
                        )
                        .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Post>())
                        .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
                        .BuildConfiguration()
                        .BuildSessionFactory()
                )
                .InSingletonScope();

            Bind<ISession>()
                .ToMethod
                (
                    c => c.Kernel.Get<ISessionFactory>().OpenSession()
                )
                .InRequestScope();
        }
    }
}