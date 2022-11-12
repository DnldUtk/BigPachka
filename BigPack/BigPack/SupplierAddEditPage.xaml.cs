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
    /// Логика взаимодействия для SupplierAddEditPage.xaml
    /// </summary>
    public partial class SupplierAddEditPage : Page
    {
        private Поставщик _currentSupplier = new Поставщик();
        public SupplierAddEditPage(Поставщик selectedSupplier)
        {
            InitializeComponent();
            if (selectedSupplier != null)
             _currentSupplier = selectedSupplier; 

            DataContext = _currentSupplier;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentSupplier.Наименование))
                errors.AppendLine("Введите наименование");
            if (_currentSupplier.Тип == null)
                errors.AppendLine("Выберите тип");
            if (string.IsNullOrWhiteSpace(_currentSupplier.ИНН))
                errors.AppendLine("Введите ИНН");
            if (_currentSupplier.Рейтинг_качества < 1 || _currentSupplier.Рейтинг_качества > 100)
                errors.AppendLine("Рейтинг - от 1 до 100");
            if (_currentSupplier.Дата_начала_работы == null)
                errors.AppendLine("Введите дату");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSupplier.ID_поставщика == 0)
                BigPachka.GetContext().Поставщик.Add(_currentSupplier);

            try
            {
                BigPachka.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
