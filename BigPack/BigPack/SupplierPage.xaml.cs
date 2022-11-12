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
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        private CheckUsers SupplierUser_;
        public SupplierPage(CheckUsers user)
        {
            InitializeComponent();
            SupplierUser_ = user;
            BtnAdd.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;
            DGTCEdit.Visibility = Visibility.Hidden;
            if (SupplierUser_.isAdmin == true)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                DGTCEdit.Visibility = Visibility.Visible;
            }
            DGridSupplier.ItemsSource = BigPachka.GetContext().Поставщик.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SupplierAddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var supplierForRemoving = DGridSupplier.SelectedItems.Cast<Поставщик>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {supplierForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BigPachka.GetContext().Поставщик.RemoveRange(supplierForRemoving);
                    BigPachka.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridSupplier.ItemsSource = BigPachka.GetContext().Поставщик.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SupplierAddEditPage((sender as Button).DataContext as Поставщик));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BigPachka.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridSupplier.ItemsSource = BigPachka.GetContext().Поставщик.ToList();
            }
        }
    }
}
