using Autofac;

namespace Finance.Infrastructure.SQLServer
{
    public class Module : Autofac.Module
    {
        public string ConnectionString { get; set; } = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AccountDB;Data Source=.";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("SQLServer"))
                .WithParameter("connectionString", ConnectionString)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
