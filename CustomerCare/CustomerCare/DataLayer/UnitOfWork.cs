using CustomerCare.DataLayer.Repositories;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.DataLayer.UnitOfWork))]
namespace CustomerCare.DataLayer
{
    public class UnitOfWork
    {
        private CustomerCareContext _context;

        public IAuthenticationRepository Authentication { get; set; }

        public IClientRepository Client { get; set; }

        public UnitOfWork()
        {
            _context = DependencyService.Get<CustomerCareContext>();

            Authentication = new AuthenticationRepository(_context);
        }
    }
}
