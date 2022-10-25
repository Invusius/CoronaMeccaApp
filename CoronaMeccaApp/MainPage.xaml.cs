namespace CoronaMeccaApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		test(); 
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	async void test()
	{

		string tester = ""; 

		tester = await SecureStorage.Default.GetAsync("oauth_token"); 

		if(tester == null)
		{
			tester = "nope"; 
		}

		testLable.Text = tester; 

		await DisplayAlert("tester", tester, "OK"); 

    }

}

