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

        private string _EditBtnText;
        public string EditBtnText { get => _EditBtnText; set { _EditBtnText = value; OnPropertyChanged(); } }

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

        private string _Batch;
        public string Batch { get => _Batch; set { _Batch = value; OnPropertyChanged(); } }

        private string _StartDate;
        public string StartDate { get => _StartDate; set { _StartDate = value; OnPropertyChanged(); } }

        private string _EndDate;
        public string EndDate { get => _EndDate; set { _EndDate = value; OnPropertyChanged(); } }

        public bool _Edit { get; set; }
        public bool Edit { get => _Edit; set { _Edit = value; OnPropertyChanged(); } }
   

        private Zone _SelectedZone;
        public Zone SelectedZone { get => _SelectedZone; set { _SelectedZone = value; OnPropertyChanged(); } }

        private Position _SelectedPosition;
        public Position SelectedPosition { get => _SelectedPosition; set { _SelectedPosition = value; OnPropertyChanged(); } }

        private Types _SelectedType;
        public Types SelectedType { get => _SelectedType; set { _SelectedType = value; OnPropertyChanged(); } }


        public BoxPageViewModel()
        {
            
            fillPickers();

            editBtn = new Command(editClick);
            saveBtn = new Command(onSave);
            backBtn = new Command(onBack);


        }
        public Box box;
        private int CurrentZoneId; 
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            EditBtnText = "Editer"; 
            Edit = false;
            box = await Api.GetboxAsync(Convert.ToInt32(query["name"]));
            if (box != null)
            {
                KasseNavn = "Kasse: " + box.name;
                CurrentZone = box.position.zone.name.ToString();
                CurrentZoneId = box.position.zone.id; 
                CurrentPosition = box.position.name.ToString();
                CurrentType = box.type.name.ToString();
                Batch = box.batch; 
                StartDate = box.created_at.ToString();
                EndDate = box.expires_at.ToString();

            }

        }

        public async void fillPickers()
        {
            zones = await Api.ZoneListAsync();
            Positions = await Api.ZonePositionsListAsync(CurrentZoneId);
            types = await Api.TyoesListAsync();

        }

        public async void fillPositions()
        {
          
            Positions = await Api.ZonePositionsListAsync(SelectedZone.id);
            

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
                EditBtnText = "Cancel"; 

            }
            else
            {
                Edit = false;
                EditBtnText = "Edit";
                SelectedPosition = null;
                SelectedType = null;
                SelectedZone = box.position.zone;
                Batch = box.batch;

            }

        }
        public async void onSave()
        {
            // update box
            CreateBox UpdateBox = new CreateBox()
            {
                name = null,
                batch = null,
                position_id = null,
                type_id = null
                
            }; 
          
            if (SelectedPosition != null)
            {
                UpdateBox.position_id = SelectedPosition.id.ToString(); 
            }
            if (SelectedType != null)
            {
                UpdateBox.type_id = SelectedType.id.ToString();
            }
            UpdateBox.batch = Batch;

            bool success = await Api.UpdateBox(box.id, UpdateBox);
            if (success)
            {
                Edit = false;
                EditBtnText = "Edit";


            }

        }
        private async void onBack()
        {
            emptyPickers();
            await Shell.Current.GoToAsync("//Home");
            await Shell.Current.GoToAsync($"/{nameof(QrPage)}");
        }
    }
}
