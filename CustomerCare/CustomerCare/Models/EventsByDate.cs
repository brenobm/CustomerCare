using System;
using System.Collections.Generic;

namespace CustomerCare.Models
{
    public class EventsByDate
    {
        public DateTime Date { get; set; }
        public IList<Event> Events { get; set; }

        public int HeightEvents
        {
            get
            {
                return (Events?.Count ?? 1) * 45;
            }
        }
    }
}
