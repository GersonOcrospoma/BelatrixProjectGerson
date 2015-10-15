using Autofac;
using UnitTestBelatrix.Modules;
using Belatrix.Entidades;
using ConsoleApp.Controller;
using Belatrix.Aplicacion.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBelatrix
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void SaveIntoBD()
        {
            var container = Bootstrapper.LoadContainer();
            var objJobLogger = new JobLogger
            {
                Mensaje = "TestSaveIntoBD",
                Tipo_Mensaje = "0"
            };

            using (var scope = container.BeginLifetimeScope())
            {
                var sresolve = scope.Resolve<IJobLoggerAplicacion>();
                var obj = new JobLoggerController(sresolve);
                var statusResponse = obj.SaveIntoBD(objJobLogger);

                Assert.AreEqual(true, statusResponse.Success);
            }
        }

        [TestMethod]
        public void SaveIntoTxt()
        {
            var container = Bootstrapper.LoadContainer();
            var objJobLogger = new JobLogger
            {
                Mensaje = "TestSaveIntoTxt",
                Tipo_Mensaje = "1"
            };

            using (var scope = container.BeginLifetimeScope())
            {
                var sresolve = scope.Resolve<IJobLoggerAplicacion>();
                var obj = new JobLoggerController(sresolve);
                var statusResponse = obj.SaveIntoTxt(objJobLogger);

                Assert.AreEqual(true, statusResponse.Success);
            }
        }

        [TestMethod]
        public void Save()
        {
            var container = Bootstrapper.LoadContainer();
            var objJobLogger = new JobLogger
            {
                Mensaje = "TestSaveIntoBDandTXT",
                Tipo_Mensaje = "2"
            };

            using (var scope = container.BeginLifetimeScope())
            {
                var sresolve = scope.Resolve<IJobLoggerAplicacion>();
                var obj = new JobLoggerController(sresolve);
                var statusResponse = obj.Save(objJobLogger);

                Assert.AreEqual(true, statusResponse.Success);
            }
        }
    }
}
