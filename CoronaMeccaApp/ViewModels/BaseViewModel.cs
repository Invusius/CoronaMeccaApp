using CoronaMeccaApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public IAPIService Api => DependencyService.Get<IAPIService>();


        bool isBusy;
        string title; 

        public bool IsBusy
        {
            get => isBusy ; 
            set
            {
                if (isBusy == value)
                    return;
                isBusy = value;
                OnPropertyChanged(); 
            } 
        }

        public string Title
        {
            get => title;
            set
            {
                if (title == value)
                    return;
                title = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null) => 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
           
        

    }
}
