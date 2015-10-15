using System;
using System.Linq;
using System.Reflection;
using Autofac;

namespace ConsoleApp.Modules
{
    public  class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("Belatrix.Aplicacion.Servicios"))
                .Where(type => type.Name.EndsWith("Servicio", StringComparison.Ordinal))
                .AsImplementedInterfaces();

            #region AsSelf

            builder.RegisterAssemblyTypes(Assembly.Load("Belatrix.Aplicacion.Servicios"))
            .Where(type => type.Name.EndsWith("Validacion", StringComparison.Ordinal))
            .AsSelf();

            builder.RegisterAssemblyTypes(Assembly.Load("Belatrix.Aplicacion.Servicios"))
                .Where(type => type.Name.EndsWith("Proceso", StringComparison.Ordinal))
                .AsSelf();

            #endregion AsSelf
        }

    }
}
