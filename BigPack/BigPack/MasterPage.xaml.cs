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
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        private CheckUsers MasterUser_;
        public MasterPage(CheckUsers user)
        {
            InitializeComponent();
            MasterUser_ = user;
            BtnAdd.Visibility = Visibility.Hidden;
            BtnDel.Visibility = Visibility.Hidden;
            DGTCEdt.Visibility = Visibility.Hidden;
            if (MasterUser_.isMaster == true) 
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnDel.Visibility = Visibility.Visible;
                DGTCEdt.Visibility = Visibility.Visible;
            }
            DGrid_smeni.ItemsSource = BigPachka.GetContext().График_смены.ToList();
        }
        private void BtnEdt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MasterEditPage((sender as Button).DataContext as График_смены));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MasterEditPage(null));
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var smeniRemove = DGrid_smeni.SelectedItems.Cast<График_смены>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {smeniRemove.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BigPachka.GetContext().График_смены.RemoveRange(smeniRemove);
                    BigPachka.GetContext().SaveChanges();
                    MessageBox.Show("Данные были успешно удалены!");
                    DGrid_smeni.ItemsSource = BigPachka.GetContext().График_смены.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
