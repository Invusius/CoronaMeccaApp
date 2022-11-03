using AndroidX.Activity;
using CoronaMeccaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.ViewModels
{
    public class BoxPageViewModel : BaseViewModel , IQueryAttributable
    {
        public Command editBtn { get; }
        public Command saveBtn { get; }
        public Command backBtn { get; }
        


        private string _KasseNavn;
        public string KasseNavn { get => _KasseNavn; set { _KasseNavn = value; OnPropertyChanged(); } }

        private string _CurrentZone;
        public string CurrentZone { get => _CurrentZone; set { _CurrentZone = value; OnPropertyChanged(); } }

        private List<Zone> _zones;
        public List<Zone> zones { get => _zones; set { _zones = value; OnPropertyChanged(); } }

        private string _CurrentPosition;
        public string CurrentPosition { get => _CurrentPosition; set { _CurrentPosition = value; OnPropertyChanged(); } }

        private List<Position> _Positions;
        public List<Position> Positions { get => _Positions; set { _Positions = value; OnPropertyChanged(); } }

        private string _CurrentType;
        public string CurrentType { get => _CurrentType; set { _CurrentType = value; OnPropertyChanged(); } }

        private List<Types> _types;
        public List<Types> types { get => _types; set { _types = value; OnPropertyChanged(); } }

        private string _StartDate;
        public string StartDate { get => _StartDate; set { _StartDate = value; OnPropertyChanged(); } }

        private string _EndDate;
        public string EndDate { get => _EndDate; set { _EndDate = value; OnPropertyChanged(); } }

        public bool _Edit { get; set; }
        public bool Edit { get => _Edit; set { _Edit = value; OnPropertyChanged(); } }
   

        private Zone _selectedZone;
        public Zone selectedZone { get => _selectedZone; set { _selectedZone = value; OnPropertyChanged(); } }

        public BoxPageViewModel()
        {
            
            fillPickers();

            editBtn = new Command(editClick);
            saveBtn = new Command(onSave);
            backBtn = new Command(onBack);


        }
        public Box box; 

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Edit = false;
            box = await Api.GetboxAsync(Convert.ToInt32(query["name"]));
           
            KasseNavn = "Kasse: " + box.name;
            CurrentZone = box.position.zone.name.ToString();
            CurrentPosition = box.position.name.ToString();
            CurrentType = box.type.name.ToString();
            StartDate = box.created_at.ToString();
            EndDate = box.expires_at.ToString();

        }

        public async void fillPickers()
        {
            zones = await Api.ZoneListAsync();
            Positions = await Api.PositionsListAsync();
            types = await Api.TyoesListAsync();

        }

        public void emptyPickers()
        {
            zones = null;
            Positions = null;
            types = null;


            KasseNavn = null;
            CurrentZone = null; 
            CurrentPosition = null;
            CurrentType = null;
            StartDate = null;    
            EndDate = null;

        }

        public void editClick()
        {
            if (Edit == false)
            {
                Edit = true;

            }
            else
            {
                Edit = false;
            }

        }
        public void onSave()
        {
            // update box
            

            CurrentZone = selectedZone.name; 
        }
        private async void onBack()
        {
            emptyPickers(); 
            await Shell.Current.GoToAsync($"/{nameof(QrPage)}");
        }
    }
}
