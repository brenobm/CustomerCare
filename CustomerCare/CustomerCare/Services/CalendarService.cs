using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.Services.CalendarService))]
namespace CustomerCare.Services
{
    public class CalendarService : ICalendarService
    {
        private IAuthenticationService authenticationService;

        public CalendarService()
        {
            authenticationService = DependencyService.Get<IAuthenticationService>();
        }

        public async Task<IEnumerable<Models.EventsByDate>> GetEventsByDay()
        {
            var events = await ListEvents();
            
            var eventsGrouped = events.GroupBy(e => e.Start.Date).ToList();

            return eventsGrouped.Select(e => new Models.EventsByDate
            {
                Date = e.Key,
                Events = e.ToList()
            });
        }

        private async Task<IList<Models.Event>> ListEvents()
        {
            try
            {
                var client = new GraphServiceClient("https://graph.microsoft.com/v1.0",
                      new DelegateAuthenticationProvider(
                      async (requestMessage) =>
                {
                    var tokenRequest = await authenticationService.LoginSilent(App.PCA.Users.FirstOrDefault());
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", tokenRequest);
                }));

                IList<Option> options = new List<Option>();

                QueryOption startDate = new QueryOption("start_datetime", DateTime.Now.ToString("o"));

                options.Add(startDate);

                var remoteEvents = await client.Me.Events.Request(options).GetAsync();

                var list = remoteEvents.ToList();

                IList<Models.Event> events = new List<Models.Event>();

                foreach (var ev in list)
                {
                    Models.Event @event = new Models.Event();

                    @event.Title = ev.Subject;
                    @event.Body = ev.BodyPreview;

                    if (ev.IsAllDay.HasValue && ev.IsAllDay.Value)
                    {
                        @event.IsAllDay = true;
                    }
                    else
                    {
                        @event.Start = DateTime.Parse(ev.Start.DateTime);
                        @event.End = DateTime.Parse(ev.End.DateTime);
                    }

                    @event.Attendees = ev.Attendees.Select(a => new Models.Attendee { Email = a.EmailAddress.Address, Name = a.EmailAddress.Name }).ToList();

                    events.Add(@event);
                }

                return events.OrderBy(e => e.Title).OrderBy(e => e.Start).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
