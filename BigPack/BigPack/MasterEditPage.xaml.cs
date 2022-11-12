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
    /// Логика взаимодействия для MasterEditPage.xaml
    /// </summary>
    public partial class MasterEditPage : Page
    {
        private График_смены currentsmeni = new График_смены();
        public MasterEditPage(График_смены selectedsmeni)
        {
            InitializeComponent();
            if (selectedsmeni != null)
            {
                currentsmeni = selectedsmeni;
            }

            DataContext = currentsmeni;
            ComboMaster.ItemsSource = BigPachka.GetContext().Мастер_смены.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            {
                StringBuilder errors = new StringBuilder();

                if (DataPickerNach.SelectedDate == null)
                {
                    errors.AppendLine("Укажите время начала смены");
                }
                if (DataPickerKon.SelectedDate == null)
                {
                    errors.AppendLine("Укажите время конца смены");
                }
                if (currentsmeni.Мастер_смены == null)
                {
                    errors.AppendLine("Укажите мастера смены");
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                if (currentsmeni.ID_смены == 0)
                {
                    BigPachka.GetContext().График_смены.Add(currentsmeni);
                }
                try
                {

                    currentsmeni.Время_начала_смены = DataPickerNach.Text;
                    currentsmeni.Время_конца_смены = DataPickerKon.Text;
                    BigPachka.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
