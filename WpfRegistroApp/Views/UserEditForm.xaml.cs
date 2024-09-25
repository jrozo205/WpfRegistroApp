using ServicesRegistroApp;
using ServicesRegistroApp.Model;
using System.Windows;
using WpfRegistroApp.ViewModels;

namespace WpfRegistroApp.Views
{
    /// <summary>
    /// Interaction logic for UserEditForm.xaml
    /// </summary>
    public partial class UserEditForm : Window
    {
        public UserEditForm(User user)
        {
            InitializeComponent();
            IUserService userService = new UserService();
            UserViewModel viewModel = new UserViewModel(userService)
            {
                User = user
            };
            this.DataContext = viewModel;
            viewModel.RequestClose += () => this.Close();
        }
    }
}
