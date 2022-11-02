using CoronaMeccaApp.Models;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.ViewModels
{
    public class CreateBoxViewModel : BaseViewModel , IQueryAttributable
    {

        public Command OpretBtn { get; } 

        private string _BoxNumber;
        public string BoxNumber { get => _BoxNumber; set { _BoxNumber = value; OnPropertyChanged(); } }

        private string _BoxName;
        public string BoxName { get => _BoxName; set { _BoxName = value; OnPropertyChanged(); } }

        private string _BatchNumber;
        public string BatchNumber { get => _BatchNumber; set { _BatchNumber = value; OnPropertyChanged(); } }
        
        private List<Zone> _zones;
        public List<Zone> zones { get => _zones; set { _zones = value; OnPropertyChanged(); } }

        private List<Position> _Positions;
        public List<Position> Positions { get => _Positions; set { _Positions = value; OnPropertyChanged(); } }

        private List<Types> _types;
        public List<Types> types { get => _types; set { _types = value; OnPropertyChanged(); } }

        private Zone _selectedZone;
        public Zone selectedZone { get => _selectedZone; set { _selectedZone = value; OnPropertyChanged(); } }
        
        private Position _selectedPosition;
        public Position selectedPosition { get => _selectedPosition; set { _selectedPosition = value; OnPropertyChanged(); } }
       
        private Types _selectedType;
        public Types selectedType { get => _selectedType; set { _selectedType = value; OnPropertyChanged(); } }


        public CreateBoxViewModel()
        {
            fillPickers();
            OpretBtn = new Command(OpretBtnclick);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            BoxNumber = query["name"].ToString();
        }

        public async void fillPickers()
        {
            zones = await Api.ZoneListAsync();
            Positions = await Api.PositionsListAsync();
            types = await Api.TyoesListAsync();

        }

        private async void OpretBtnclick()
        {
            if (BoxName != null && selectedPosition != null && selectedType != null && BatchNumber != null)
            {
                await createBox(); 

            }
            else
            {
                // error mesage
            }
        }


        private async Task<bool> createBox()
        {

                CreateBox createBox = new CreateBox()
                {
                    position_id = selectedPosition.id,
                    type_id = selectedType.id,
                    name = BoxNumber,
                    batch = BatchNumber
                }; 

                bool success = await Api.CreateBox(createBox);
                if (success == true)
                {
                    
            
                    return true;
                }
                else
                {
                    return false; 
                }
           

        }



    }
}
