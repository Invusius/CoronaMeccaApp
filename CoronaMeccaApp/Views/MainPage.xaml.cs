using AndroidX.Lifecycle;
using System.Collections.ObjectModel;

namespace CoronaMeccaApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public ObservableCollection<int> Test { get; }

    public List<int> zones { get; set; }

    public MainPage()
	{
		InitializeComponent();
        
		Test = new ObservableCollection<int>();
        

        test();
        zones = new List<int>();
		

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{

		Test.Add(1); 
		
		zones.Add(1);

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


    }

}

