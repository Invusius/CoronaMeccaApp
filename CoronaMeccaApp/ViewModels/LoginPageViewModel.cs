using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaMeccaApp.Models;
using AndroidX.Annotations;
using CoronaMeccaApp.Services;

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

            }
            else
            {

                LoginError = "Udfyld venligst alle felterne";

            }

        }


        private async Task<bool> login()
        {

            APIService api = new APIService();


            User loginUser = new User() {
                email = Username,
                password = Password
            };

            bool success = await Api.LoginAsync(loginUser);
            if (success == true)
            {
                // Set navigation to home setting
                await Shell.Current.GoToAsync("//Home");

                // Navigate to mainpage
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                return true;
            }
            else
            {

                LoginError = "brugernavn eller password er forkert ";
                return false;
            }


        }



    }
}
