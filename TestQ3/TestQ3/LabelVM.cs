using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestQ3
{
    class LabelV:Label ,INotifyPropertyChanged
    {
        public object textContent
        {
            get
            {
                return this.Content;
            }
            set
            {
                this.Content = value;
                OnPropertyChanged("Content");
               
            }
        }
            
          
        public LabelV()
        {
            this.textContent = Content;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
