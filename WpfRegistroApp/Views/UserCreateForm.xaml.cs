using ServicesRegistroApp.Model;
using ServicesRegistroApp;
using System.Windows;
using WpfRegistroApp.ViewModels;

namespace WpfRegistroApp.Views
{
    /// <summary>
    /// Interaction logic for UserCreateForm.xaml
    /// </summary>
    public partial class UserCreateForm : Window
    {
        public UserCreateForm()
        {
            InitializeComponent();
            IUserService userService = new UserService();
            UserViewModel viewModel = new UserViewModel(userService)
            {
                User = new User()
            };
            this.DataContext = viewModel;
            viewModel.RequestClose += () => this.Close();
        }
    }
}
