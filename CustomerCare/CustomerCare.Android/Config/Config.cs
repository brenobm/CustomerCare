using Android.Content;
using Android.Net;
using Android.OS;
using CustomerCare.Config;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.Droid.Config.Config))]
namespace CustomerCare.Droid.Config
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
                    _platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
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
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                        _deviceId = Build.Serial;
                    else
                    {
                        var field = Java.Lang.Class.FromType(typeof(Build)).GetField("SERIAL");
                        _deviceId = field.Get(null).ToString();
                    }
                }

                return _deviceId;
            }
        }

        public bool ConnectionActive
        {
            get
            {
                ConnectivityManager cm =
                    (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
                NetworkInfo netInfo = cm.ActiveNetworkInfo;
                return netInfo != null && netInfo.IsConnectedOrConnecting;
            }
        }
    }
}