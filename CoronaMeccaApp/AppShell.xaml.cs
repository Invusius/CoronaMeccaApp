using CoronaMeccaApp.Views;

namespace CoronaMeccaApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(QrPage), typeof(QrPage));
        Routing.RegisterRoute(nameof(BoxPage), typeof(BoxPage));
        Routing.RegisterRoute(nameof(CreateBoxPage), typeof(CreateBoxPage));
        Routing.RegisterRoute(nameof(ZonePage), typeof(ZonePage));


    }
}
