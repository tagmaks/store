using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using GenericServices;
using GenericServices.Services;
using GenericServices.Services.Concrete;
using GenericServices.ServicesAsync;
using GenericServices.ServicesAsync.Concrete;
using Spa.Dtos;
using Spa.Infrastructure;

namespace Spa
{
    public partial class Startup
    {
        private void ConfigureDi(HttpConfiguration httpConfig)
        {
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //set Entity Framework context to instance per lifetime scope. 
            //This is important as we get one context per lifetime, so all db classes are tracked together.
            builder.RegisterType<AppDbContext>().As<IGenericServicesDbContext>().InstancePerLifetimeScope();

            //Autowire all 
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(SpaRepository<,,>))
               .As(typeof(ISpaRepository<,,>))
               .InstancePerRequest()
               .PropertiesAutowired();

            #region Property injection <TEntity>
            builder.RegisterGeneric(typeof(ListService<>))
                .As(typeof(IListService<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailServiceAsync<>))
                .As(typeof(IDetailServiceAsync<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailService<>))
                .As(typeof(IDetailService<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(CreateServiceAsync<>))
                .As(typeof(ICreateServiceAsync<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(UpdateServiceAsync<>))
                .As(typeof(IUpdateServiceAsync<>))
                .InstancePerRequest();
            #endregion

            #region Property injection <TEntity, TDto>
            builder.RegisterGeneric(typeof(ListService<,>))
                .As(typeof(IListService<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailServiceAsync<,>))
                .As(typeof(IDetailServiceAsync<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailService<,>))
                .As(typeof(IDetailService<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(CreateServiceAsync<,>))
                .As(typeof(ICreateServiceAsync<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(UpdateServiceAsync<,>))
                .As(typeof(IUpdateServiceAsync<,>))
                .InstancePerRequest();
            #endregion

            IContainer container = builder.Build();

            // Set the dependency resolver for Web Api
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        
    }
}