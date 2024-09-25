using System.ComponentModel;

namespace ServicesRegistroApp.Model
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        private string _identification;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        private string _address;
        private Area _area;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Identification
        {
            get { return _identification; }
            set
            {
                _identification = value;
                OnPropertyChanged(nameof(Identification));
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public Area Area
        {
            get { return _area; }
            set
            {
                _area = value;
                OnPropertyChanged(nameof(Area));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
