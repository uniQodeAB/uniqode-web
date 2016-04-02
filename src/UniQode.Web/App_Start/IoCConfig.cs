using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using UniQode.Contracts;
using UniQode.Data;
using UniQode.Data.Models;
using UniQode.Data.Repositories;
using UniQode.Services.Cache;

namespace UniQode.Web
{
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<DefaultCacheProvider>()
                .As<ICacheProvider>()
                .SingleInstance();

            builder
                .RegisterType<AdminModel>()
                .InstancePerRequest() //todo: SingleInstance?
                ;//.PreserveExistingDefaults();
            builder
                .RegisterType<PrimaryModel>()
                .InstancePerRequest() //todo: SingleInstance?
                ;//.PreserveExistingDefaults();
            builder
                .RegisterType<SecondaryModel>()
                .InstancePerRequest() //todo: SingleInstance?
                ;//.PreserveExistingDefaults();

            //builder
            //    .RegisterGeneric(typeof(Repository<,>))
            //    .As(typeof(IRepository<,>))
            //    .InstancePerRequest();
            
            builder
                .RegisterGeneric(typeof(AdminRepository<>))
                .As(typeof(IAdminRepository<>))
                .InstancePerRequest();
            builder
                .RegisterGeneric(typeof(PrimaryRepository<>))
                .As(typeof(IPrimaryRepository<>))
                .InstancePerRequest();
            builder
                .RegisterGeneric(typeof(SecondaryRepository<>))
                .As(typeof(ISecondaryRepository<>))
                .InstancePerRequest();


            builder.RegisterControllers(typeof (Global).Assembly);
            
            builder.RegisterAssemblyModules(typeof(Global).Assembly);
            
            builder.RegisterModule<AutofacWebTypesModule>();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}