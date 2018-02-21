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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsAllDay { get; set; }
        public TimeSpan Duration
        {
            get
            {
                if (!IsAllDay)
                    return End - Start;
                else
                    return TimeSpan.MinValue;
            }
        }
        public string DurationFormated
        {
            get
            {
                if (IsAllDay)
                    return String.Empty;

                string durationFormated = string.Empty;

                if (Duration.Hours > 0)
                {
                    durationFormated = $"{Duration.Hours} h";
                }

                if (Duration.Minutes > 0)
                {
                    durationFormated += $"{Duration.Minutes} h";
                }

                return durationFormated;
            }
        }

        public string AttendeesList
        {
            get
            {
                return string.Join("\r\n", Attendees);
            }
        }
    }
}
