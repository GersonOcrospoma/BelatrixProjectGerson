using System;
using Belatrix.Entidades;
using Belatrix.Aplicacion.Interfaces;


namespace ConsoleApp.Controller
{
    public class JobLoggerController
    {
        private readonly IJobLoggerAplicacion _IJobLoggerAplicacion;

        public JobLoggerController(IJobLoggerAplicacion IJobLoggerAplicacion)
        {
            _IJobLoggerAplicacion = IJobLoggerAplicacion;
        }

        public StatusResponse Save(JobLogger objJobLogger)
        {

            var savetxt = _IJobLoggerAplicacion.SaveIntoTxt(objJobLogger);
            if (!savetxt.Success)
                return new StatusResponse { Success = savetxt.Success, Messages = savetxt.Messages };

            var savebd = _IJobLoggerAplicacion.SaveIntoBD(objJobLogger);
            if (!savebd.Success)
                return new StatusResponse { Success = savebd.Success, Messages = savebd.Messages };

            ColorEnConsola(objJobLogger.Tipo_Mensaje);
            return new StatusResponse { Success = true, Message = objJobLogger.Mensaje };
        }
        private static void ColorEnConsola(string tipo)
        {
            switch (tipo)
            {
                case "0":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "1":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        #region Testing
        //Only for Testing
        public StatusResponse SaveIntoBD(JobLogger objJobLogger)
        {
            return _IJobLoggerAplicacion.SaveIntoBD(objJobLogger);
        }

        public StatusResponse SaveIntoTxt(JobLogger objJobLogger)
        {
            return _IJobLoggerAplicacion.SaveIntoTxt(objJobLogger);
        }
        #endregion Testing
    }
}
