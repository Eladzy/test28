using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestQ3
{
     class DownLoadRequest:MainWindow
     {
        //object SizeLabelContent { get => sizeLbl.Content; set => sizeLbl.Content = value; }
        static bool isFInished = false;
         public async void GetSize(string url)
         {

             WebRequest webRequest = WebRequest.Create($@"{url}");
            WebResponse response =await webRequest.GetResponseAsync();
             using (StreamReader reader = new StreamReader(response.GetResponseStream()))
             {
                 string text = reader.ReadToEndAsync().ToString();
                MessageBox.Show(text);
             }
             isFInished = true;
           
            
         }
     }
}
