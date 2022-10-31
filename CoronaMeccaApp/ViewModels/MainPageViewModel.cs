using CoronaMeccaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CoronaMeccaApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        public Command onCounterClicked { get; }

        private string _CounterBtn;
        public string CounterBtn { get => _CounterBtn; set { _CounterBtn = value; OnPropertyChanged(); } }

        private List<Zone> _zones;
        public List<Zone> zones { get => _zones; set { _zones = value; OnPropertyChanged(); } }

        int count = 0;


        public MainPageViewModel()
        {
            onCounterClicked = new Command(OnCounterClicked);

            FillList(); 
        }

        private async void FillList()
        {
            CounterBtn = await SecureStorage.Default.GetAsync("oauth_token");


            zones = await Api.ZoneListAsync();


        }

        private void OnCounterClicked(object sender)
        {

            count++;

            if (count == 1)
                CounterBtn = $"Clicked {count} time";
            else
                CounterBtn= $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn);
        }

    }
}
