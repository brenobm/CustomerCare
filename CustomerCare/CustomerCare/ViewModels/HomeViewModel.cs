using CustomerCare.Helpers;
using CustomerCare.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CustomerCare.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private ICalendarService calendarService;

        public ObservableCollection<Models.EventsByDate> EventsByDate { get; set; }

        public HomeViewModel()
        {
            calendarService = DependencyService.Get<ICalendarService>();

            EventsByDate = new ObservableCollection<Models.EventsByDate>();

            Initialize();
        }

        private async void Initialize()
        {
            var events = await calendarService.GetEventsByDay();

            EventsByDate.Clear();

            foreach(var e in events)
            {
                EventsByDate.Add(e);
            }
        }
    }
}
