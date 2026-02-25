using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Group1_Login.Model;
using Group1_Login.View;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Group1_Login.ViewModel
{
    public class ProfileModelView : INotifyPropertyChanged
    {
       private UserModel _CurrentUser;

        public string FirstName
        {
            get => _CurrentUser.FirstName;
            set { _CurrentUser.FirstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        public string MiddleName
        {
            get => _CurrentUser.MiddleName;
            set { _CurrentUser.MiddleName = value; OnPropertyChanged(nameof(MiddleName)); }
        }
        public string LastName
        {
            get => _CurrentUser.LastName;
            set { _CurrentUser.LastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        public string Address
        {
            get => _CurrentUser.Address;
            set { _CurrentUser.Address = value; OnPropertyChanged(nameof(Address)); }
        }
        public string Religion
        {
            get => _CurrentUser.Religion;
            set { _CurrentUser.Religion = value; OnPropertyChanged(nameof(Religion)); }
        }

        public ICommand EditCommand { get; set; }

        public ProfileModelView(UserModel user)
        {
            _CurrentUser = user ?? new UserModel();
            EditCommand = new RelayCommand(Edit);
        }
        private void Edit(object parameter)
        {
            InputProfile newWindow = new InputProfile();
            newWindow.DataContext = new InputProfileViewModel(_CurrentUser);
            newWindow.Show();

            if (parameter is Window window)
                window.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        }
}
