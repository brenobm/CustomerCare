using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCare.Services
{
    public interface ICalendarService
    {
        Task<IEnumerable<Models.EventsByDate>> GetEventsByDay();
    }
}
