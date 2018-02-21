using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCare.Models
{
    public class Event
    {
        public Event()
        {
            Attendees = new List<Attendee>();
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public IList<Attendee> Attendees { get; set; }
        public DateTime TimeEvent { get; set; }

        public string AttendeesList
        {
            get
            {
                return string.Join("\r\n", Attendees);
            }
        }
    }
}
