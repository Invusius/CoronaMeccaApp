namespace CoronaMeccaApp;

public partial class QrPage : ContentPage
{
	public QrPage()
	{
		InitializeComponent();

	}
	bool isadd = false;

	private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
        if (isadd == false)
        {
			qrlable.Text = "se info";
			// send get request
        }
        else
        {
			qrlable.Text = "add info";
			// send post request 
        }
        /*
        Dispatcher.Dispatch(() =>
		{
			// get barcode result e.Results[0].Value; 
			qrlable.Text = e.Results[0].Value; 

        }); 
		*/

    }

	private void addBTN_Clicked(object sender, EventArgs e)
	{
		

		if(isadd == false)
		{
			addBTN.Source = "plus.png";
            isadd = true;

        }
		else
		{
            addBTN.Source = "plusnofill.png";
            isadd = false;
        }

    }
}