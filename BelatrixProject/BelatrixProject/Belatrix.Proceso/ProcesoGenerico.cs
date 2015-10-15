using System;
using System.Collections.Generic;
using System.Linq;
using Belatrix.Entidades;

namespace Belatrix.Proceso
{
    public abstract class ProcesoGenerico<T> where T : class
    {
        private readonly List<string> _list;
        private readonly StatusResponse _status;


        protected ProcesoGenerico()
        {
            _list = new List<string>();
            _status = new StatusResponse();
        }

        protected StatusResponse Status
        {
            get { return _status; }
        }
        #region abstract

        protected abstract StatusResponse SaveIntoTxt(T request);
        protected abstract StatusResponse SaveIntoBD(T request);

        #endregion abstract


        #region virtual

        protected virtual List<string> Validate(T request)
        { return _list; }

        #endregion virtual

        #region public
        public StatusResponse EjecutaSaveIntoTxt(T request)
        {
            return Execute(() => Validate(request), () => SaveIntoTxt(request));
        }

        public StatusResponse EjecutaSaveIntoBD(T request)
        {
            return Execute(() => Validate(request), () => SaveIntoBD(request));
        }
        #endregion public

        #region private methods

        private StatusResponse Execute(Func<List<string>> funcToVal, Func<StatusResponse> funcToRun)
        {
            var errors = funcToVal();

            if (errors.Any())
            {
                _status.Success = false;
                _status.Messages = errors;

                return _status;
            }
            _status.Success = true;

            return funcToRun();
        }

        #endregion
    }
}
