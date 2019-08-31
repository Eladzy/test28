using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TestQ3
{
    class ViewModel
    {
        public ICommand MyCommand { get; set; }
        public ICommand MyRealayCommand { get; set; }
        public DelegateCommand MyDelegate { get; set; }
        public ViewModel()
        {
            MyCommand = new Commands();
            MyRealayCommand = new RelayCommand((o)=> { return true; },(o)=> { MessageBox.Show("111"); });
         
        }
    }
}
