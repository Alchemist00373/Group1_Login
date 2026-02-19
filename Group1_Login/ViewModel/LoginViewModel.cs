using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Group1_Login.Model;
using Group1_Login.View;
using System.Windows;

namespace Group1_Login.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public event Action LoginSucceeded;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            if (parameter is PasswordBox passwordBox)
            {
                Password = passwordBox.Password;
            }

            UserModel loggedInUser = UserService.Users
                .Find(u => u.Username == Username && u.Password == Password);

            if (loggedInUser != null)
            {
                LoginSucceeded?.Invoke();
                System.Windows.MessageBox.Show("Congratulations! Login Successful.");

                // Pass the logged-in user to the dashboard
                DashBoardView newWindow = new DashBoardView
                {
                    DataContext = new DashBoardViewModel(loggedInUser)
                };
                newWindow.Show();

                Application.Current.MainWindow.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Invalid username or password.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}