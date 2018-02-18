using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCare.Services
{
    public interface ICalendarService
    {
        Task<IList<Models.Event>> TestIntegration();
    }
}
