using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.Services.AuthenticationService))]
namespace CustomerCare.Services
{
    class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> Login()
        {
            try
            {
                AuthenticationResult ar = await App.PCA.AcquireTokenAsync(App.Scopes, App.UiParent);

                App.Current.Properties["accessToken"] = ar.AccessToken;
                App.Current.Properties["idToken"] = ar.IdToken;
                App.Current.Properties["userName"] = ar.User.Name;

                return true;

            }
            catch (MsalException ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                Debug.Write($"{this.GetType().FullName} - {sf.GetMethod().Name} - {ex.Message}");
            }

            return false;
        }
    }
}
