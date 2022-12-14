using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using CoronaMeccaApp.Services;
using CoronaMeccaApp.ViewModels;
using CoronaMeccaApp.Views;

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
        builder.Services.AddSingleton<BoxPage>();
        builder.Services.AddSingleton<BoxPageViewModel>();
        builder.Services.AddSingleton<CreateBoxPage>();
        builder.Services.AddSingleton<CreateBoxViewModel>(); 
		builder.Services.AddSingleton<ZonePage>();
        builder.Services.AddSingleton<ZonePageViewModel>();

        return builder.Build();
	}
}
