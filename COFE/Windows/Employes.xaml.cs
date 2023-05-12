using COFE.ClassHelper;
using COFE.DB;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace COFE.Windows
{
    /// <summary>
    /// Логика взаимодействия для Employes.xaml
    /// </summary>
    public partial class Employes : Window
    {
        public Employes()
        {
            InitializeComponent();
            listviewUsers.ItemsSource = HELP.Context.User.ToList().Where(u=>u.IDUser!=2);
            listviewUsers.MouseEnter+= OnMouseEnterButton1;
        }
        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
          
        }

        private void addemploye_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee=new AddEmployee();
            addEmployee.Show();
            this.Close();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (listviewUsers.SelectedIndex == -1)
            {

                MessageBox.Show("Сотрудник не выбран");
            }
            else
            {
                UpdateEmployee updateEmployee = new UpdateEmployee();
                Application.Current.Resources["Employee"]=listviewUsers.SelectedItems[0];
                MessageBox.Show(listviewUsers.SelectedItems[0].ToString());
                  
              //  updateEmployee.Show();
             //   this.Close();
            }
        }
    }
}
