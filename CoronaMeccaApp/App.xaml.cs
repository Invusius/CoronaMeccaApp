using CoronaMeccaApp.Services;

namespace CoronaMeccaApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        DependencyService.Register<APIService>();

        MainPage = new AppShell();
	}

	

}
