using Belatrix.Entidades;

namespace Belatrix.Aplicacion.Interfaces
{
    public interface IJobLoggerAplicacion
    {
        StatusResponse SaveIntoTxt(JobLogger objJobLogger);
        StatusResponse SaveIntoBD(JobLogger objJobLogger);
    }
}
