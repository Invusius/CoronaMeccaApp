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

}