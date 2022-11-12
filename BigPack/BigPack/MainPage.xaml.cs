using System;
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

namespace BigPack
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private CheckUsers _user;
        public MainPage(CheckUsers user)
        {
            InitializeComponent();
            _user = user;
        }
        private void BtnMaterial_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MaterialPage(_user));
        }
        private void BtnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SupplierPage(_user));
        }
        private void BtnMaster_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MasterPage(_user));
        }
    }
}
