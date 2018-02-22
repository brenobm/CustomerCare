using CustomerCare.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.DataLayer.Repositories.AuthenticationRepository))]
namespace CustomerCare.DataLayer.Repositories
{
    public class AuthenticationRepository : RepositoryBase<Authentication>, IAuthenticationRepository
    {
        public AuthenticationRepository(CustomerCareContext context) : base(context)
        {
        }
    }
}
