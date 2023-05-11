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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using COFE.ClassHelper;
using COFE.DB;
using System.Data.Entity.Migrations;

namespace COFE.Windows
{
    /// <summary>
    /// Логика взаимодействия для PlaceOrder.xaml
    /// </summary>
    public partial class PlaceOrder : Window
    {
        public PlaceOrder()
        {
            InitializeComponent();
            GetProduct();

        }

        private void GetProduct()
        {
            List<Product> OrderList = new List<Product>();

            OrderList = HELP.Context.Product.ToList();

            LVOrder.ItemsSource = OrderList;
        }
        Check check = new Check();

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int user = (int)Application.Current.Properties["All"];
            var v = HELP.Context.User.Where(p=>p.IDUser==user);
            var y = HELP.Context.Check.Count();
         
            check.IDCheck = y+1;
            check.IDUser = v.ToList()[0].IDUser;
            
        
            HELP.Context.Check.Add(check);
            check.IDUser = v.ToList()[0].IDUser;
            
            HELP.Context.Check.Add(check);
            HELP.Context.SaveChanges();
      
            ProductCheck productCheck = new ProductCheck();



            productCheck.IDProduct = (LVOrder.SelectedItem as DB.Product).IDProduct;


            productCheck.IDCheck = check.IDCheck;
            HELP.Context.ProductCheck.AddOrUpdate(
                h => h.IDCheck,
                productCheck);

            Application.Current.Properties["CHECK"] = check.IDCheck;
            //  Help.Context.ProductCheck.AddOrUpdate(productCheck);


            HELP.Context.SaveChanges();
            MessageBox.Show("Успешно");
            Windows.Basket bascet = new Basket();
            bascet.Show();

        }
    }

}
