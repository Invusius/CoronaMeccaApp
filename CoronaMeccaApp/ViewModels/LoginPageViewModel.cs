using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {

        public Command logincommand { get; }


        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public LoginPageViewModel()
        {
            logincommand = new Command(LoginBTN_Clicked); 

        }

        private async void LoginBTN_Clicked(object sender)
        {
            
            if (Username != null && Password != null)
            {
                await login();
                // logind
                await Shell.Current.GoToAsync("//Home");
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");


                //await Navigation.PushAsync(new MainPage());

            }
            else
            {

                //await DisplayAlert("UPS", "Udfyld venligst alle felterne", "OK");

            }
            
           
        }


        private async Task<bool> login()
        {
            /*
            client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("");

            response.EnsureSuccessStatusCode(); 
            var jsonstring = await response.Content.ReadAsStringAsync();
            var User = JsonConvert.DeserializeObject(jsonstring);

            if (User != null)
            {


                return true;

            }
            else
            {
                return false;
            }
            */
            await SecureStorage.Default.SetAsync("oauth_token", "testval");
            return true;
        }

    }
}
