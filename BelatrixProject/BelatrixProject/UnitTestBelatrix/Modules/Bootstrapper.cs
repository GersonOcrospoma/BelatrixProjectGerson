using Autofac;

namespace UnitTestBelatrix.Modules
{
    public static  class Bootstrapper
    {
        public static IContainer LoadContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServicesModule>();
            return builder.Build();
        }
    }
}
