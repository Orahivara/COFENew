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

namespace COFE.Windows
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public Basket()
        {
            InitializeComponent();
            GetProduct();

        }

        private void GetProduct()
        {
            List<BasketAll> OrderList = new List<BasketAll>();
            int check = (int)Application.Current.Properties["CHECK"];
            OrderList = HELP.Context.BasketAll.ToList().Where(P => P.IDCheck ==check);

            listv.ItemsSource = OrderList;
        }
    }
}