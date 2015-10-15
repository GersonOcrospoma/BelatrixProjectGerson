using System.Collections.Generic;

namespace Belatrix.Entidades
{
    public class StatusResponse<T> : StatusResponse
    {
        public T Data { get; set; }
    }
    public class StatusResponse
    {
        public StatusResponse()
        {
            Messages = new List<string>();
        }

        public bool Success { get; set; }

        public string Message { get; set; } //Un Mensaje

        public object Value { get; set; }

        public List<string> Messages { get; set; } //Lista de Mensajes
    }
}