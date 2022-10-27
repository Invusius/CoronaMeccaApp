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


        int count = 0;



        public ObservableCollection<int> Test { get; }

        public List<int> zones { get; set; }

        public MainPageViewModel()
        {
            onCounterClicked = new Command(OnCounterClicked);

            


            Test = new ObservableCollection<int>();

            zones = new List<int>();

            test();

        }

        private void OnCounterClicked(object sender)
        {

            Test.Add(1);

            zones.Add(1);

            count++;

            if (count == 1)
                CounterBtn = $"Clicked {count} time";
            else
                CounterBtn= $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn);
        }

        async void test()
        {
            CounterBtn = await SecureStorage.Default.GetAsync("oauth_token");

            string tester = "";

            tester = await SecureStorage.Default.GetAsync("oauth_token");

            if (tester == null)
            {
                tester = "nope";
            }

            //testLable.Text = tester;


        }

    }
}
