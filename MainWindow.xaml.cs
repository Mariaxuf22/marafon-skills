using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Timer = System.Timers.Timer;

namespace Marafon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public String Time 
        { 
            get
            {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("2016 - 10 - 21 6:00");

            TimeSpan ts = dt2 -dt1;
            return string.Format("{0} дн {1} ч {2} мин {3} сек до старта марафона!", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
            }
        
        
        }
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext= this;
        }

        ~MainWindow() 
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            Timer tmr = new Timer();

            tmr.Interval = 1000;
            tmr.Elapsed += tmr_Elapsed;

            tmr.Start();
        }


        private void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PropertyChange("Time");
        }

        private void PropertyChange(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void Button_bClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
