using System.Collections.Generic;


namespace Belatrix.Proceso
{
    public abstract class ValidacionBase
    {
        protected List<string> Msg { get; set; }

        protected ValidacionBase()
        {
            Msg = new List<string>();
        }
    }
}
