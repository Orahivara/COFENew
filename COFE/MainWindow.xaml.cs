using COFE.ClassHelper;
using COFE.DB;
using System;
using System.Collections.Generic;
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
using COFE.ClassHelper;
using COFE.DB;

namespace COFE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DB.User> users = new List<DB.User>();
        public MainWindow()
        {
            InitializeComponent();
            users = HELP.Context.User.ToList();
            // table.ItemsSource = users;
            // end.Text = users[1].ToString();
        }
    
        private void _in_Click(object sender, RoutedEventArgs e)
        {
            var correct = HELP.Context.User.FirstOrDefault(u => u.Login == login.Text && u.Password == password.Text);
            if (correct != null)
            {
                string fio = string.Concat(correct.FirstName);
                Application.Current.Properties["Name"] = fio;
                Application.Current.Properties["Role"] = correct.IDTypeOfUser;
                Application.Current.Properties["All"] =Convert.ToInt32(correct.IDUser);
                Windows.Choose choose = new Windows.Choose();
                choose.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");

            }
        }

        private void inlikeguest_Click(object sender, RoutedEventArgs e)
        {
            var correct = HELP.Context.User.First(u => u.IDUser == 0);
            Application.Current.Properties["Name"] = correct.FirstName.ToString();
            Application.Current.Properties["Role"] = correct.IDTypeOfUser;
            Windows.Choose choose = new Windows.Choose();
            choose.Show();
            this.Close();
        }

        private void signin_Click(object sender, RoutedEventArgs e)
        {
            Windows.Registration registration = new Windows.Registration();
            registration.Show();
            this.Close();
        }
    }
}
