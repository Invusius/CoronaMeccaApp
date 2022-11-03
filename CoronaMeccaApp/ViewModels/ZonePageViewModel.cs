using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.ViewModels
{
    public class ZonePageViewModel : BaseViewModel , IQueryAttributable
    {
        private string _ZoneName;
        public string ZoneName { get => _ZoneName; set { _ZoneName = value; OnPropertyChanged(); } }

        public ZonePageViewModel()
        {

        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ZoneName = query["name"].ToString();
        }

    }
}
