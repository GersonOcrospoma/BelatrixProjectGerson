using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using cn = Belatrix.DAO;
using Belatrix.Entidades;
using Belatrix.Proceso;
using System.Data.SqlClient;
using Belatrix.Aplicacion.Servicios.Validacion;

namespace Belatrix.Aplicacion.Servicios.Proceso
{
   public class JobLoggerAplicacionProceso : ProcesoGenerico<JobLogger>
    {
        private readonly JobLoggerAplicacionValidacion _validacion;

        public JobLoggerAplicacionProceso(JobLoggerAplicacionValidacion validacion)
        {
            _validacion = validacion;
        }
        protected override List<string> Validate(JobLogger request)
        {
            var x = _validacion.Validar(request);
            return x;
        }

        protected override StatusResponse SaveIntoBD(JobLogger request)
        {
            var connection = cn.Connection.GetInstance;
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Insert into Log Values('" + request.Mensaje + "'," + request.Tipo_Mensaje.ToString() + ")"
            };

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                this.Status.Success = true;
                this.Status.Message = "El mensaje se insertó correctamente.";
            }
            catch (Exception ex)
            {
                this.Status.Success = false;
                this.Status.Messages.Add("Error: " + ex.Message);
            }
            return this.Status;
        }

        protected override StatusResponse SaveIntoTxt(JobLogger request)
        {
            string l = String.Empty;
            var path = ConfigurationManager.AppSettings["LogFileDirectory"];
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var ruta = path + "LogFile_" + string.Format("{0:d-M-yyyy_HHmmss}", DateTime.Now) + ".txt";
           

            try
            {
                if (!File.Exists(ruta))
                    File.Create(ruta).Close();
                else
                    l = File.ReadAllText(ruta);

                l = string.Concat(l, DateTime.Now.ToShortDateString(), ": ", request.Mensaje, Environment.NewLine);

                File.WriteAllText(ruta, l);

                this.Status.Success = true;
                this.Status.Message = "El archivo se guardo correctamente";
            }
            catch (Exception ex)
            {
                this.Status.Success = false;
                this.Status.Messages.Add("Error: " + ex.Message);
            }

            return this.Status;
        }
    }
}
