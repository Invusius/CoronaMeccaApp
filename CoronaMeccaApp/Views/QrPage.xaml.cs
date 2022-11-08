using Android.Hardware;
using Android.Hardware.Camera2;
using CoronaMeccaApp.ViewModels;

namespace CoronaMeccaApp;

public partial class QrPage : ContentPage
{
    public QrPage(QrPageViewModel qrPageViewModel)
    {
        InitializeComponent();
        BindingContext = qrPageViewModel;

    }

    private async void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {

        await ((QrPageViewModel)BindingContext).ScanComplete(e.Results[0].Value);


    }

    // zxing camera bug workaround zing wont open the camera again after it has been closed 
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Camera.Open();
        
    }

 

 
}