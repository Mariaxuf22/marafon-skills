using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Marafon
{
    /// <summary>
    /// Логика взаимодействия для WindCharity.xaml
    /// </summary>
    public partial class WindCharity : Window
    {
        public WindCharityInfo(Charity charity)
        {
            InitializeComponent();

            label_charityName.Content = charity.CharityName;
            Textblock.Text = charity.CharityDescription;

            Image.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"charities", Charity.CharityLogo)));
        }
    }
}
