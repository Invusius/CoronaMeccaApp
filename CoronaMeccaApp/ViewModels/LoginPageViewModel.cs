using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaMeccaApp.Models;
using AndroidX.Annotations;

namespace CoronaMeccaApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {

        public Command logincommand { get; }


        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private string _LoginError;
        public string LoginError { get => _LoginError; set { _LoginError = value; OnPropertyChanged(); } }

        HttpClient client; 

        public LoginPageViewModel()
        {
            logincommand = new Command(LoginBTN_Clicked);
            //LoginError = ""; 
        }
        //string test; 

        private async void LoginBTN_Clicked(object sender)
        {
            
            if (Username != null && Password != null)
            {
                await login();


                //await SecureStorage.Default.SetAsync("oauth_token", test);

                // logind
                /*
                await Shell.Current.GoToAsync("//Home");
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                */

                //await Navigation.PushAsync(new MainPage());

            }
            else
            {

                //await DisplayAlert("UPS", "Udfyld venligst alle felterne", "OK");

            }
            
           
        }


        private async Task<bool> login()
        {
            
            client = new HttpClient();

            User loginUser = new User() {
                email = Username,
                password = Password
            };

            using (var content = new StringContent(JsonConvert.SerializeObject(loginUser), Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync("https://vacapi.semeicardia.online/api/authenticate/app", content);
                /*
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    LoginError = "error 1";

                    return false;
                }
                */
                if (!response.IsSuccessStatusCode)
                {
                    LoginError = "brugernavn eller password er forkert "; 
                    return false;
                }

                var jsonstring = await response.Content.ReadAsStringAsync();
            
                dynamic values = JsonConvert.DeserializeObject<dynamic>(jsonstring);

                if (jsonstring != null)
                {
                    string test = values[1].token;
                    //await settoken(values[1].token); 
                    await SecureStorage.Default.SetAsync("oauth_token", test);
                    
                    await Shell.Current.GoToAsync("//Home");
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                    
                    return true;

                }
                else
                {

                    return false;
                }
            }

            
        }



    }
}
