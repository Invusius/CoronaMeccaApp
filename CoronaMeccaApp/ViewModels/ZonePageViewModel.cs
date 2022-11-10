using CoronaMeccaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.ViewModels
{
    public class ZonePageViewModel : BaseViewModel , IQueryAttributable
    {
        public Command backBtn { get; }


        private string _ZoneName;
        public string ZoneName { get => _ZoneName; set { _ZoneName = value; OnPropertyChanged(); } }

        private string _ZoneTemp;
        public string ZoneTemp { get => _ZoneTemp; set { _ZoneTemp = value; OnPropertyChanged(); } }

        private string _ZoneHum;
        public string ZoneHum { get => _ZoneHum; set { _ZoneHum = value; OnPropertyChanged(); } }

        private Zone zone; 


        public ZonePageViewModel()
        {
            backBtn = new Command(onBack); 
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            zone = await Api.ZoneAsync(Convert.ToInt32(query["name"].ToString()));
            ZoneName = zone.name;
            ZoneTemp = "Temperatur: " + zone.latest_log.temperature + " C" ;
            ZoneHum = "Luftfugtighed: " + zone.latest_log.humidity + " %";

        }

        private async void onBack()
        {
            await Shell.Current.GoToAsync("//Home");

            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }

    }
}
