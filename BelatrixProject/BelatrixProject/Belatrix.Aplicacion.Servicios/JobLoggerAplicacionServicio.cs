using Belatrix.Aplicacion.Servicios.Proceso;
using Belatrix.Aplicacion.Interfaces;
using Belatrix.Entidades;

namespace Belatrix.Aplicacion.Servicios
{
    public class JobLoggerAplicacionServicio : IJobLoggerAplicacion
    {
        private readonly JobLoggerAplicacionProceso _jobLoggerAplicacionProceso;

        //Constructor
        public JobLoggerAplicacionServicio(JobLoggerAplicacionProceso jobLoggerAplicacionProceso)
        {
            _jobLoggerAplicacionProceso = jobLoggerAplicacionProceso;
        }


        public StatusResponse SaveIntoBD(JobLogger objJobLogger)
        {
            return _jobLoggerAplicacionProceso.EjecutaSaveIntoBD(objJobLogger);
        }

        public StatusResponse SaveIntoTxt(JobLogger objJobLogger)
        {
            return _jobLoggerAplicacionProceso.EjecutaSaveIntoTxt(objJobLogger);
        }
    }
}
