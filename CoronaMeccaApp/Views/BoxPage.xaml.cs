using CoronaMeccaApp.ViewModels;

namespace CoronaMeccaApp;

public partial class BoxPage : ContentPage
{
	public BoxPage(BoxPageViewModel boxPageViewModel)
	{
		InitializeComponent();

		BindingContext = boxPageViewModel; 
		

    }

	private void ZonePicker_SelectedIndexChanged(object sender, EventArgs e)
	{
        ((BoxPageViewModel)BindingContext).fillPositions();

    }
}