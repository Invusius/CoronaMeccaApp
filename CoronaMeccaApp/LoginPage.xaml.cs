using Newtonsoft.Json;

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
			await login(); 
            // logind
            await Shell.Current.GoToAsync("//Home"); 

            await Navigation.PushAsync(new MainPage()); 

		}
		else
		{

			await DisplayAlert("UPS", "Udfyld venligst alle felterne", "OK"); 

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