using CoronaMeccaApp.ViewModels;
using Newtonsoft.Json;

namespace CoronaMeccaApp;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		BindingContext = loginPageViewModel;

    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//Home");
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}