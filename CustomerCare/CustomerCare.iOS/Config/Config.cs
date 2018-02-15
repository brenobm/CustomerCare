using CustomerCare.Config;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.iOS.Config.Config))]
namespace CustomerCare.iOS.Config
{
    public class Config : IConfig
    {
        private string _databasePath;
        private ISQLitePlatform _platform;
        private string _deviceId;

        public string DatabasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_databasePath))
                {
                    _databasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                    _databasePath = System.IO.Path.Combine(_databasePath, "..", "Library");
                }

                return _databasePath;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (_platform == null)
                {
                    _platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return _platform;
            }
        }

        public string DeviceId
        {
            get
            {
                if (string.IsNullOrEmpty(_deviceId))
                {
                    _deviceId = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
                }

                return _deviceId;
            }
        }

        public bool ConnectionActive
        {
            get
            {
                return Reachability.InternetConnectionStatus() != NetworkStatus.NotReachable;
            }
        }
    }
}