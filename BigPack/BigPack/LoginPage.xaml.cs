using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        BigPachka db = new BigPachka();
        DBConnect DB = new DBConnect();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
       
        public LoginPage()
        {
            InitializeComponent();
            
        }
        //public string GetHash(string input)
        //{
        //    var md5 = MD5.Create();
        //    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

        //    return Convert.ToBase64String(hash);
        //}
        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            table.Rows.Clear();
            var loginUser = textBox_login.Text;
            var passwordUser = passwordBox_password.Password;

            string QueryString = $"select id_user, login, password, isUser, isAdmin, isMaster from users where login ='{loginUser}' and password ='{passwordUser}'";
            SqlCommand command = new SqlCommand(QueryString, DB.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (textBox_login.Text.Length > 0)
            {
                if (passwordBox_password.Password.Length > 0)
                {
                    if (table.Rows.Count == 1)
                    {
                        var user = new CheckUsers(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[3]), Convert.ToBoolean(table.Rows[0].ItemArray[4]), Convert.ToBoolean(table.Rows[0].ItemArray[5]));
                        if (user.isUser == true)
                        {
                            MessageBox.Show("Вы успешно вошли как Пользователь!");
                            Manager.MainFrame.Navigate(new MainPage(user));
                        }
                        else
                        {
                            if (user.isAdmin == true)
                            {
                                MessageBox.Show("Вы успешно вошли как Администратор!");
                                Manager.MainFrame.Navigate(new MainPage(user));
                            }
                            else 
                            {
                                if (user.isMaster == true) 
                                {
                                    MessageBox.Show("Вы успешно вошли как Мастер смены!");
                                    Manager.MainFrame.Navigate(new MainPage(user));
                                }
                            }
                        }
                    }
                    else MessageBox.Show("Неверно введен логин или пароль!");

                }
                else { MessageBox.Show("Введите пароль!"); }

            }
            else { MessageBox.Show("Введите логин!"); }
        }
    }
}
