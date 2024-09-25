using Microsoft.SqlServer.Server;
using ServicesRegistroApp;
using ServicesRegistroApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfRegistroApp.Views
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersForm : Window
    {
        IUserService userServices;

        public UsersForm()
        {
            InitializeComponent();
            InitializeServices();

            LoadUsers();
        }

        public void InitializeServices() 
        {
            userServices = new UserService();
        }

        private void LoadUsers()
        {
            var users = userServices.GetUsers();
            dgUsers.ItemsSource = users;
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userSelected = (User)((Button)e.Source).DataContext;
                var user = userServices.GetUserById(userSelected.Id);

                UserEditForm userEditForm = new UserEditForm(user);
                userEditForm.ShowDialog();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserCreateForm userCreateForm = new UserCreateForm();
                userCreateForm.ShowDialog();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
