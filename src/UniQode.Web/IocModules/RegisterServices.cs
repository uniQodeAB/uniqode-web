using Autofac;
using UniQode.Contracts.Services;
using UniQode.Services;

namespace UniQode.Web.IocModules
{
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AccountService>()
                .As<IAccountService>()
                .InstancePerRequest();

            builder
                .RegisterGeneric(typeof(MultiTenantService<,>))
                .As(typeof(IMultiTenantService<,>))
                .InstancePerRequest();
        }
    }
}