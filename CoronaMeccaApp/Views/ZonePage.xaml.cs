using CoronaMeccaApp.ViewModels;

namespace CoronaMeccaApp.Views;

public partial class ZonePage : ContentPage
{
	public ZonePage(ZonePageViewModel zonePageViewModel)
	{
		InitializeComponent();

		BindingContext = zonePageViewModel; 

    }
}