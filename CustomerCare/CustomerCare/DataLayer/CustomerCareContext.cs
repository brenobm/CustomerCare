using CustomerCare.Config;
using CustomerCare.Models;
using SQLite.Net;
using Mono.Data.Sqlite;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.DataLayer.CustomerCareContext))]
namespace CustomerCare.DataLayer
{
    public class CustomerCareContext: IDisposable
    {
        private SQLiteConnection _connection;

        public SQLiteConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public CustomerCareContext()
        {
            try
            {
                IConfig config = DependencyService.Get<IConfig>();

                _connection = new SQLiteConnection(config.Platform, Path.Combine(config.DatabasePath, "database.db3"));

                _connection.CreateTable<Authentication>();
                
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                Debug.Write($"{this.GetType().FullName} - {sf.GetMethod().Name} - {ex.Message}");

                throw;
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
