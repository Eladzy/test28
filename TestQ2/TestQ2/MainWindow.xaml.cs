using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestQ2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static bool isClicked = false;
        int i = 30;
        public MainWindow()
        {
          
           InitializeComponent();
            if(isClicked==false)
            CountAsync();

        }
        private void Option3Btn_Click(object sender, RoutedEventArgs e)
        {
            isClicked = true;
            WrongAnswer();
        }
        private void Option4Btn_Click(object sender, RoutedEventArgs e)
        {
            isClicked = true;
            WrongAnswer();
        }
        private void Option1Btn_Click(object sender, RoutedEventArgs e)
        {
            //correct
            isClicked = true;
            option1Btn.Foreground = new SolidColorBrush(Colors.Green);
            Action action = CorrectAnswer;
            SafeInvoke(action);
        }
        private void Option2Btn_Click(object sender, RoutedEventArgs e)
        {
            isClicked = true;
            WrongAnswer();
        }
        void WrongAnswer()
        {
            Background = new SolidColorBrush(Colors.Red);
            option1Btn.IsEnabled = false;
            option2Btn.IsEnabled = false;
            option3Btn.IsEnabled = false;
            option4Btn.IsEnabled = false;

        }
        void CorrectAnswer()
        {
           
           
            Background = new SolidColorBrush(Colors.Green);
            option1Btn.IsEnabled = false;
            option2Btn.IsEnabled = false;
            option3Btn.IsEnabled = false;
            option4Btn.IsEnabled = false;
        }
        public async void CountAsync()
        {
            if (isClicked)
                return;
            for (i = 30; i >= 0; i--)
            {
                if (isClicked)
                {

                    break;
                }
                timeLbl.Content = i.ToString();
                await Task.Run(() =>
                {
                  
                    Thread.Sleep(1000);
                    if (i == 16&&isClicked==false)
                    {
                        Action action = On15Sec;
                        SafeInvoke(action);
                    }
                    if (i == 0)
                    {
                        Action action = OnTimesUp;
                        SafeInvoke(action);
                    }
                 
                });
              
            }

        }

       
        private void OnTimesUp()
        {
           
            WrongAnswer();

        }

        private void On15Sec()
        {
            timeLbl.Foreground=new SolidColorBrush(Colors.Red);
        }
        private void SafeInvoke(Action action)
        {
            if (Dispatcher.CheckAccess())
            {
                action.Invoke();
                return;
            }
            this.Dispatcher.Invoke(action);
        }
    }
}
