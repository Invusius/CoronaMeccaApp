using CoronaMeccaApp.ViewModels;

namespace CoronaMeccaApp;

public partial class KassePage : ContentPage
{
	public KassePage(KassePageViewModel kassePageViewModel)
	{
		InitializeComponent();

		BindingContext = kassePageViewModel; 

    }
}