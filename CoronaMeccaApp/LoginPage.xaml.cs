namespace CoronaMeccaApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		

    }
    HttpClient client;

	private async void LoginBTN_Clicked(object sender, EventArgs e)
	{

		if (Username.Text != null && Password != null)
		{

			// logind
			await Shell.Current.GoToAsync("//Home"); 

            await Navigation.PushAsync(new MainPage()); 

		}
		else
		{

			await DisplayAlert("UPS", "Udfyld venligst alle felterne", "OK"); 

		}


	}



}