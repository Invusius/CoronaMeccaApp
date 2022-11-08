using AndroidX.Annotations;
using CoronaMeccaApp.Models;
using CoronaMeccaApp.Views;
using Java.Lang;
//using CoronaMeccaApp.Views;
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

        private string _qrErrorText;
        public string qrErrorText { get => _qrErrorText; set { _qrErrorText = value; OnPropertyChanged(); } }


        public QrPageViewModel()
        {
            addBtnCommand = new Command(addBtnClick);
            //QrRead = new barc(CameraBarcodeReaderView_BarcodesDetected);
            //qrText = "qr test";
            addBtnSource = "plusnofill.png";

        }

        bool isadd = false;
        private Box box; 
        public async Task<bool> ScanComplete(object sender)
        {
            if(int.TryParse(sender.ToString(), out int value) )
            {
                box = await Api.GetboxAsync(Convert.ToInt32(sender.ToString())); 
                if (isadd == false)
                {
                
                    if(box != null)
                    {
                        qrErrorText = "";
                        //back button test 
                    

                        await Shell.Current.GoToAsync($"//{nameof(BoxPage)}?name={sender.ToString()}");

                    }
                    else
                    {
                        qrErrorText = "Kassen findes Ikke"; 
                    }
               
                }
                else
                {
                    if(box == null)
                    {
                        qrErrorText = "";

                        await Shell.Current.GoToAsync($"//{nameof(CreateBoxPage)}?name={sender.ToString()}");

                    }
                    else
                    {
                        qrErrorText = "Kassen eksisterer alerede "; 
                    }

                }
            }

            return true; 
        }

        private void addBtnClick(object sender)
        {
             
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
