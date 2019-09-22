using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Prism;
using System.Net;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using System.Threading;

namespace Q3
{
    class CommandAndPropertiesVM:ICommand,INotifyPropertyChanged
    {
        /*
         In order to move between Dispatcher/Task and Async/Await mods
             comment out The Irrelavt method
             
             
             */
        Dispatcher dispatcher = MainWindow.dispatcher;
        private Object sizeContent;

        public Object SizeContent
        {
            get { return this.sizeContent; }
            set { this.sizeContent = value; OnPropertyChanged("sizeContent"); }
        }

        private string url;
        public string Url
        {
            get { return this.url; }
            set { this.url = value; OnPropertyChanged("url"); }
        }
        public static bool isFInished = true;
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool CanExecute(object parameter)
        {
         
           return isFInished;
        }

        public void Execute(object parameter)
        {
            //commet the irrelevant method
           //GetSizeAsync(url);
            GetSizeTask(url);
        }
        //------------------->async/await
        public async void GetSizeAsync(string url)
        {
            this.SizeContent = "Proccessing...";
            isFInished = false;

            WebRequest webRequest = WebRequest.Create(url);
            WebResponse response = await webRequest.GetResponseAsync();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var text = reader.ReadToEndAsync().Result;
                this.SizeContent = $"{text.Length} Bytes";
            }
            isFInished = true;
        }
        //----------->Task
        public void GetSizeTask(string url)
        {
            this.SizeContent = "Proccessing...";
            isFInished = false;
            Task.Run(() => 
            {
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse response = webRequest.GetResponse();
                Action a = () =>
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        var text = reader.ReadToEndAsync().Result;
                        this.SizeContent = $"{text.Length} Bytes";
                    }
                };
                SafeInvoke(a);
                isFInished = true;
            });
        }
        void SafeInvoke(Action action)
        {
            if (Thread.CurrentThread==Dispatcher.CurrentDispatcher.Thread)//an alternative to Dispatcher.CheckAccess()
            {
                action.Invoke();
                return;
            }
            this.dispatcher.Invoke(action);
        }
    }
}
