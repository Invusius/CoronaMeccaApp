using Android.Hardware;
using CoronaMeccaApp.ViewModels;

namespace CoronaMeccaApp;

public partial class QrPage : ContentPage
{
    public QrPage(QrPageViewModel qrPageViewModel)
    {
        InitializeComponent();
        BindingContext = qrPageViewModel;

    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {

        ((QrPageViewModel)BindingContext).ScanComplete(e.Results[0].Value);



    }

    // zxing camera bug workaround zing wont open the camera again after it has been closed 
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        Camera.Open();


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Camera.Open();

    }

 
}