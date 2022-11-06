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



        public ZonePageViewModel()
        {
            backBtn = new Command(onBack); 
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ZoneName = query["name"].ToString();
        }

        private async void onBack()
        {
            await Shell.Current.GoToAsync($"/{nameof(MainPage)}");
        }

    }
}
