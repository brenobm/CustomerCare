using SQLite.Net.Interop;

namespace CustomerCare.Config
{
    public interface IConfig
    {
        string DatabasePath { get; }
        ISQLitePlatform Platform { get; }
        string DeviceId { get; }
        bool ConnectionActive { get; }
    }
}
