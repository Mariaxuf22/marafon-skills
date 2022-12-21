using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Marafon
{
    /// <summary>
    /// Логика взаимодействия для sponsorpagee.xaml
    /// </summary>
    public partial class sponsorpagee : Page, INotifyPropertyChanged
    {
        public int donate;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Donation
        {
            get
            {
                return donate;
            }
            set
            {
                int temp = 0;

                int.TryParse(value.ToString(), out temp);

                if (temp >= 10)
                {
                    donate = value;
                }
            }
        }

        public sponsorpagee()
        {
            InitializeComponent();
        }




        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<RunnerInfo> runnerInfo = new List<RunnerInfo>();
            Util.Db.Runner.ToList().ForEach(r => runnerInfo.Add(new RunnerInfo() { runner = r }));
            //comboBox_runner.ItemsSource = runnerInfo;
            //comboBox_runner.DisplayMemberPath = "runnerInfo";
            this.DataContext = this;
            donate = 50;
            comboBox_runner.SelectedItem = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void comboBox_runner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RunnerInfo runner = comboBox_runner.SelectedItem as RunnerInfo;
            Registration reg = runner.runner.Registration.Last();

            if (reg != null)
            {
                Charity charity = reg.Charity;
                label_charity.Content = charity.CharityName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            donate -= 10;
        }

        private void button_sub_Click(object sender, RoutedEventArgs e)
        {
            if (donate >= 20)
            {
                donate -= 10;
                PropertyChange("donation");
            }
        }


        private void PropertyChange(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RunnerInfo runner = comboBox_runner.SelectedItem as RunnerInfo;
            Registration reg = runner.runner.Registration.Last();

            if (reg != null)
            {
                new WindCharity(reg.Charity).ShowDialog();
            }
        }



        internal class label_charity
        {
            internal static string Content;
        }

        private void button_pay_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text) || textBox_name.Text.Length <= 0)
            {
                MessageBox.Show("Введите ваше имя");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textbox_card.Text) || textbox_card.Text.Length <= 0)
            {
                MessageBox.Show("Введите владельца карты");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textbox_cardnum.Text) || textbox_cardnum.Text.Length != 16)
            {
                MessageBox.Show("Введите номер карты");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textbox_card_mon.Text) || textbox_card_mon.Text.Length < 1)
            {
                MessageBox.Show("Введите месяц");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textbox_card_year.Text) || textbox_card_year.Text.Length != 4)
            {
                MessageBox.Show("Введите год");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textbox_card_cvc.Text) || textbox_card_cvc.Text.Length != 3)
            {
                MessageBox.Show("Введите CVC");
                return;
            }
            Sponsorship sponsor = new Sponsorship();
            sponsor.Amount = donate;
            sponsor.Registration = (comboBox_runner.SelectedItem as RunnerInfo).registration;
            sponsor.SponsorName = textBox_name.Text;

            try 
            {
                Util.Db.Sponsorship.Add(sponsor);
                Util.Db.SaveChanges();  
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении");
            }
            finally
            {
                NavigationService.Navigate(new SponsorshipSuccessPage(comboBox_runner.SelectedItem as RunnerInfo));
            }
        }
    }
}


