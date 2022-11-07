using CoronaMeccaApp.Models;
using CoronaMeccaApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace CoronaMeccaApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel , INotifyPropertyChanged
    {
        public Command OnLOgoutBtn { get; }

        public Command OnListBtnClick { get; }

        private string _CounterBtn;
        public string CounterBtn { get => _CounterBtn; set { _CounterBtn = value; OnPropertyChanged(); } }

        private Zone _ZoneSelected;
        public Zone ZoneSelected{ get => _ZoneSelected; set { _ZoneSelected = value; OnPropertyChanged(); } }

        private List<Zone> _zones;
        public List<Zone> zones { get => _zones; set { _zones = value; OnPropertyChanged(); } }


        public MainPageViewModel()
        {
            OnListBtnClick = new Command(listBtnClick);
            OnLOgoutBtn = new Command(Logout); 

            FillList();
        }

        private async void FillList()
        {
            CounterBtn = await SecureStorage.Default.GetAsync("oauth_token");


            zones = await Api.ZoneListAsync();


        }
        private async void listBtnClick ()
        {

            await Shell.Current.GoToAsync($"//{nameof(ZonePage)}?name={ZoneSelected.id.ToString()}");

        }
        
        private async void Logout()
        {
            // Set navigation to home setting
            await Shell.Current.GoToAsync("//Login");

            // Navigate to mainpage
            await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
            SecureStorage.Default.Remove("oauth_token");

        }


    }
}
