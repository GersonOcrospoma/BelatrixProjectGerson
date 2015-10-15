using Autofac;

namespace ConsoleApp.Modules
{
    public static class Bootstrapper
    {
        //Working with Autofac
        public static IContainer LoadContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServicesModule>();
            return builder.Build();
        }
    }
}
