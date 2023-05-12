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
using System.Windows.Shapes;

namespace COFE.Windows
{
    /// <summary>
    /// Логика взаимодействия для Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
        public Choose()
        {
            InitializeComponent();
            hi.Text = "Аве ," + Application.Current.Properties["Name"].ToString();
            if(Convert.ToInt32(Application.Current.Properties["Role"])!=2)
            {
                something.IsEnabled = true;
                employ.IsEnabled = true;

            }
        }

        private void products_Click(object sender, RoutedEventArgs e)
        {
            Windows.PlaceOrder order = new PlaceOrder();
            order.Show();
            this.Close();
         
        }

        private void something_Click(object sender, RoutedEventArgs e)
        {
            Windows.Users users = new Users();
            users.Show();
            this.Close();
           
        }

        private void employ_Click(object sender, RoutedEventArgs e)
        {
            Windows.Employes employes = new Employes();
            employes.Show();
            this.Close();
           
        }
    }
}
