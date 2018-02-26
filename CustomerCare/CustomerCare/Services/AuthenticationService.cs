using CustomerCare.DataLayer;
using CustomerCare.Models;
using Microsoft.Identity.Client;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.Services.AuthenticationService))]
namespace CustomerCare.Services
{
    class AuthenticationService : IAuthenticationService
    {
        private UnitOfWork _uow;

        public AuthenticationService()
        {
            _uow = DependencyService.Get<UnitOfWork>();
        }

        public async Task<bool> Login()
        {
            try
            {
                AuthenticationResult ar = await App.PCA.AcquireTokenAsync(App.Scopes, App.UiParent);
                                
                InsertAuthenticateUser(ar);

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

        public async Task<string> GetCurrentToken(IUser user)
        {
            try
            {
                AuthenticationResult ar = await App.PCA.AcquireTokenSilentAsync(App.Scopes, user);

                return ar.AccessToken;
            }
            catch (MsalException ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                Debug.Write($"{this.GetType().FullName} - {sf.GetMethod().Name} - {ex.Message}");
            }

            return null;
        }

        public async Task<bool> LoginSilent(IUser user)
        {
            try
            {
                AuthenticationResult ar = await App.PCA.AcquireTokenSilentAsync(App.Scopes, user);

                InsertAuthenticateUser(ar);

                return true;
            }
            //catch (MsalException ex)
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                Debug.Write($"{this.GetType().FullName} - {sf.GetMethod().Name} - {ex.Message}");
            }

            return false;
        }

        public bool Logout()
        {
            try
            {
                foreach (var a in _uow.Authentication.List(at => at.Active))
                {
                    a.Active = false;
                    _uow.Authentication.Update(a);
                }

                App.PCA.Remove(App.Current.Properties["user"] as IUser);

                App.Current.Properties.Remove("accessToken");
                App.Current.Properties.Remove("idToken");
                App.Current.Properties.Remove("userName");
                App.Current.Properties.Remove("user");

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

        public async Task<bool> CurrentLogged()
        {
            var auth = _uow.Authentication.List(a => a.Active).FirstOrDefault();

            if (auth == null)
            {
                return false;
            }

            return await LoginSilent(auth);
        }

        private void InsertAuthenticateUser(AuthenticationResult ar)
        {
            IUser user = App.PCA.Users.FirstOrDefault();

            App.Current.Properties["accessToken"] = ar.AccessToken;
            App.Current.Properties["idToken"] = ar.IdToken;
            App.Current.Properties["userName"] = user.Name;
            App.Current.Properties["user"] = user;

            Authentication auth = new Authentication
            {
                AccessToken = ar.AccessToken,
                IdToken = ar.IdToken,
                Name = user.Name,
                DisplayableId = user.DisplayableId,
                Identifier = user.Identifier,
                IdentityProvider = user.IdentityProvider,
                Active = true
            };

            foreach (var a in _uow.Authentication.List(at => at.Active))
            {
                a.Active = false;
                _uow.Authentication.Update(a);
            }

            _uow.Authentication.Insert(auth);
        }


    }
}
