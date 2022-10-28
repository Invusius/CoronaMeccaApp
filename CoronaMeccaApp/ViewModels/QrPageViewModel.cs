using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;

namespace CoronaMeccaApp.ViewModels
{
    public class QrPageViewModel : BaseViewModel
    {

        public Command addBtnCommand { get; }

        private string _qrText;
        public string qrText { get => _qrText; set { _qrText = value; OnPropertyChanged(); } }
       
        private string _addBtnSource;
        public string addBtnSource { get => _addBtnSource; set { _addBtnSource = value; OnPropertyChanged(); } }


        public QrPageViewModel()
        {
            addBtnCommand = new Command(addBtnClick);
            //QrRead = new barc(CameraBarcodeReaderView_BarcodesDetected);
            //qrText = "qr test";
            addBtnSource = "plusnofill.png";

        }

        bool isadd = false;
        
        public void ScanComplete(object sender)
        {
            
            if (isadd == false)
            {
                qrText = "se info";
                // send get request
            }
            else
            {
                qrText = "add info";
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

        private void addBtnClick(object sender)
        {
            qrText = "tester2";

            if (isadd == false)
            {
                addBtnSource = "plus.png";
                isadd = true;

            }
            else
            {
                addBtnSource = "plusnofill.png";
                isadd = false;
            }

        }

    }
}
