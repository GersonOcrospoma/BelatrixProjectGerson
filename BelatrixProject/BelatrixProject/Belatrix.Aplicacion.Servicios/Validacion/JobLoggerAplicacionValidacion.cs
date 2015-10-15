using System.Collections.Generic;
using Belatrix.Entidades;
using Belatrix.Proceso;


namespace Belatrix.Aplicacion.Servicios.Validacion
{
    public class JobLoggerAplicacionValidacion : ValidacionBase
    {
        public List<string> Validar(JobLogger request)
        {
            if (string.IsNullOrEmpty(request.Mensaje) || string.IsNullOrWhiteSpace(request.Mensaje))
                Msg.Add("Ingrese un mensaje.");
            if (!request.Tipo_Mensaje.Equals("0") && !request.Tipo_Mensaje.Equals("1") && !request.Tipo_Mensaje.Equals("2"))
                Msg.Add("El tipo de mensaje ingresado es incorrecto.");
            return Msg;
        }
    }
}
