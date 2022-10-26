using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using CoronaMeccaApp.Services;
using CoronaMeccaApp.ViewModels;

namespace CoronaMeccaApp;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		 
		builder
			.UseMauiApp<App>()
			.UseBarcodeReader()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<APIService>();
        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<QrPage>();
        builder.Services.AddSingleton<QrPageViewModel>();
        
		return builder.Build();
	}
}
