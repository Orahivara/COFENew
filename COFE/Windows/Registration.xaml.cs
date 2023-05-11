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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            type.ItemsSource = HELP.Context.UserType.ToList();
            type.SelectedIndex = 1;

            type.DisplayMemberPath = "NameTypeOfUser";

            //   type.Items.Add(1);
            //     type.Items.Add(2);
            //     type.Items.Add(3);



        }
        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedState = type.SelectedItem.ToString();
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            User adduser = new User();
            if (FIO.Text != "" && login.Text != "" && password.Text != "" && email.Text != "" && phone.Text != "")

            {
                string text = loh.Text;
                try
                {
                    string[] name = FIO.Text.Split(new char[] { ' ' });
                    adduser.FirstName = name[1];
                    adduser.LastName = name[0];
                    adduser.Patronimic = name[2];
                    adduser.Email = email.Text;

                    adduser.Phone = phone.Text;
                    adduser.Login = login.Text;
                    adduser.Password = password.Text;
                    adduser.IDTypeOfUser = (type.SelectedItem as DB.UserType).IDType;

                    Application.Current.Properties["Role"] = (type.SelectedItem as DB.UserType).IDType;
                    if (male.IsChecked == true)
                    {

                        //   adduser.IDGender = (male.SelectedItem as DB.Gender).IDGender;

                    }
                    if (femail.IsChecked == true) { adduser.IDGender = (string)male.Content; }
                    HELP.Context.User.Add(adduser);

                    HELP.Context.SaveChanges();
                    PlaceOrder placeOrder = new PlaceOrder();
                    placeOrder.Show();
                    this.Close();

                }
                catch (Exception)
                {

                    MessageBox.Show("Данные введены невено");
                }
                
                //string[] name = FIO.Text.Split(new char[] { ' ' });
                //adduser.FirstName = name[1];
                //adduser.LastName = name[0];
                //adduser.Patronimic = name[2];
                //adduser.Email = email.Text;

                //adduser.Phone = phone.Text;
                //adduser.Login = login.Text;
                //adduser.Password = password.Text;
                //adduser.IDTypeOfUser = (type.SelectedItem as DB.UserType).IDType;

                //Application.Current.Properties["Role"] = (type.SelectedItem as DB.UserType).IDType;
                //if (male.IsChecked == true)
                //{

                //    //   adduser.IDGender = (male.SelectedItem as DB.Gender).IDGender;

                //}
                //if (femail.IsChecked == true) { adduser.IDGender = (string)male.Content; }
                //HELP.Context.User.Add(adduser);

                //HELP.Context.SaveChanges();
                //PlaceOrder placeOrder = new PlaceOrder();
                //placeOrder.Show();
                //this.Close();



            }
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            if (femail.IsChecked == true)
            {
                femail.IsChecked = false;
            }
        }

        private void femail_Checked(object sender, RoutedEventArgs e)
        {
            if (male.IsChecked == true)
            {
                male.IsChecked = false;
            }
        }

    }
}
