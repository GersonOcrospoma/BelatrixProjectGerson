using System.Configuration;
using System.Data.SqlClient;

namespace Belatrix.DAO
{
    public static class Connection
    {
        private static SqlConnection instance = null;
        private static readonly object lockThis = new object();
        private static readonly string ConnectionStr = ConfigurationManager.AppSettings["ConnectionString"];

        public static SqlConnection GetInstance
        {
            get
            {
                lock (lockThis)
                {
                    if (instance == null)
                        instance = new SqlConnection(ConnectionStr);
                    return instance;
                }
            }
        }
        public static void Open()
        {
            if (instance != null)
                instance.Open();
        }
        public static void Close()
        {
            if (instance != null)
                instance.Close();
        }
    }
}
