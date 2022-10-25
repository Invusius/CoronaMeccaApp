namespace CoronaMeccaApp;

public partial class QrPage : ContentPage
{
	public QrPage()
	{
		InitializeComponent();
	}

	private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{

		Dispatcher.Dispatch(() =>
		{
			// get barcode result e.Results[0].Value; 
			qrlable.Text = e.Results[0].Value; 

        }); 


	}
}