//using AndroidX.Lifecycle;
using CoronaMeccaApp.ViewModels;
using System.Collections.ObjectModel;

namespace CoronaMeccaApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();

        BindingContext = mainPageViewModel;


    }
    
    

}

