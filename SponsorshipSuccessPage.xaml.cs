﻿using System;
using System.Collections.Generic;
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

namespace Marafon
{
    /// <summary>
    /// Логика взаимодействия для SponsorshipSuccessPage.xaml
    /// </summary>
    public partial class SponsorshipSuccessPage : Page
    {
        public SponsorshipSuccessPage(RunnerInfo runner, Charity charity)
        {
            InitializeComponent();
            label_amount.Content = donation;
            label_charity.Content = charity.CharityName;
            label_runner.Content = string.Format("{0} {1} из {2}" , runner.runner.User.FirstName, runner.runner.User.LastName, runner.runner.Country.CountryName);
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage()); 
        }
    }
}
