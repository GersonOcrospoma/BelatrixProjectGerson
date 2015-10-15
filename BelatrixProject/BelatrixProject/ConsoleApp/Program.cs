using System;
using Belatrix.Aplicacion.Interfaces;
using Autofac;
using Autofac.Core;
using ConsoleApp.Modules;
using Belatrix.Entidades;
using ConsoleApp.Controller;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ejecutar();
        }
        private static void Ejecutar()
        {
            var container = Bootstrapper.LoadContainer();
            var objJobLogger = new JobLogger();
            Console.WriteLine("Ingrese el tipo de mensaje: ");
            Console.WriteLine("0 - Error");
            Console.WriteLine("1 - Warning");
            Console.WriteLine("2 - Mensaje");
            objJobLogger.Tipo_Mensaje = Console.ReadLine();

            Console.WriteLine("Ingrese el mensaje: ");
            objJobLogger.Mensaje = Console.ReadLine();

            using (var scope = container.BeginLifetimeScope())
            {

                var sresolve = scope.Resolve<IJobLoggerAplicacion>();
                var obj = new JobLoggerController(sresolve);

                var statusResponse = obj.Save(objJobLogger);

                if (statusResponse.Success)
                    Console.WriteLine(DateTime.Now.ToShortDateString() + ": " + statusResponse.Message);
                else
                    Console.WriteLine(DateTime.Now.ToShortDateString() + ": " + string.Join(string.Empty, statusResponse.Messages));

            }
            Console.ReadLine();
            Console.Clear();
            Ejecutar();
        }
    }
}
