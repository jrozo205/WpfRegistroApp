using ServicesRegistroApp;
using ServicesRegistroApp.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace WpfRegistroApp.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;

        private User _user;
        private Area _areaSelected;
        public ICommand UpdateCommand { get; }
        public ICommand CreateCommand { get; }
        public ObservableCollection<Area> Areas { get; set; }

        public event Action RequestClose;

        public Area AreaSelected
        {
            get { return _areaSelected; }
            set
            {
                _areaSelected = value;
                OnPropertyChanged(nameof(AreaSelected));
            }
        }

        public UserViewModel(IUserService userService) 
        {
            _userService = userService;
            _user = new User();
            Areas = new ObservableCollection<Area>();
            UpdateCommand = new RelayCommand(Update, CanUpdate);
            CreateCommand = new RelayCommand(Create, CanCreate);
            LoadAreas();
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));

                if(_user != null && _user.Area != null && _user.Area.Id > 0)
                    AreaSelected = Areas.FirstOrDefault(a => a.Id == _user.Area.Id);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CanUpdate(object parameter)
        {
            return ValidatePhoneAndEmail();
        }

        private bool CanCreate(object parameter)
        {
            bool arePhoneAndEmailValid = ValidatePhoneAndEmail();
            bool areOtherFieldsValid = false;

            if (string.IsNullOrWhiteSpace(_user.Identification)
                || string.IsNullOrWhiteSpace(_user.FirstName)
                || string.IsNullOrWhiteSpace(_user.LastName))
            {
                return false;
            }
            else 
            {
                areOtherFieldsValid = true;
            }

            if (arePhoneAndEmailValid && areOtherFieldsValid)
                return true;
            else 
                return false;
        }

        private bool ValidatePhoneAndEmail()
        {
            if (string.IsNullOrWhiteSpace(_user.Phone) || string.IsNullOrWhiteSpace(_user.Email))
            {
                return false;
            }

            //if (!Regex.IsMatch(_user.Phone, @"^\d{3}-\d{3}-\d{4}$"))
            //{
            //    return false;
            //}

            if (!Regex.IsMatch(_user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            return true;
        }

        private void Update(object parameter)
        {
            try
            {
                _user.Area = AreaSelected;
                var result = _userService.UpdateUser(_user);

                string message = string.Empty;
                if (result)
                    message = "Usuario actualizado correctamente.";
                else
                    message = "El usuario no pudo ser actualizado";

                MessageBox.Show(message);
                RequestClose?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}");
            }
        }

        private void LoadAreas()
        {
            try
            {
                var areasFromBD = _userService.GetAreas();

                Areas.Clear();
                foreach (var area in areasFromBD)
                {
                    Areas.Add(area);
                }

                if (Areas.Count > 0)
                {
                    AreaSelected = Areas[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las áreas: {ex.Message}");
            }
        }

        private void Create(object parameter)
        {
            try
            {
                _user.Area = AreaSelected;
                var result = _userService.CreateUser(_user);

                string message = string.Empty;
                if (result) 
                    message = "Usuario creado correctamente.";
                else
                    message = "El usuario no pudo ser creado";

                MessageBox.Show(message);
                RequestClose?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el usuario: {ex.Message}");
            }
        }


    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
