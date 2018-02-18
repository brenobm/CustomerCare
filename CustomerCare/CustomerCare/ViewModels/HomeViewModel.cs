﻿using CustomerCare.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CustomerCare.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private ICalendarService calendarService;

        public ObservableCollection<Models.Event> Events { get; set; }

        public HomeViewModel()
        {
            calendarService = DependencyService.Get<ICalendarService>();

            Events = new ObservableCollection<Models.Event>();

            Initialize();
        }

        private async void Initialize()
        {
            var events = await calendarService.TestIntegration();

            Events.Clear();

            foreach(var e in events)
            {
                Events.Add(e);
            }
        }
    }
}