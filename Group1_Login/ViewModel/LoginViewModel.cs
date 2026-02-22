using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Group1_Login.View;

namespace Group1_Login.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            string password = passwordBox.Password;

            if (Username == "admin" && password == "1234")
            {
                DashBoardView dashboard = new DashBoardView();
                dashboard.Show();

                Application.Current.Windows[0].Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password",
                                "Login Failed",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
