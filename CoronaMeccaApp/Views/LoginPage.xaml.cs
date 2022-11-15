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


}