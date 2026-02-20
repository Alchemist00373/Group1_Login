using Group1_Login.Model;
using Group1_Login.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Group1_Login.ViewModel;

namespace Group1_Login.ViewModel
{
    public class InputProfileViewModel : INotifyPropertyChanged
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

        public ICommand SubmitCommand { get; set; }

        public InputProfileViewModel()
        {
            _CurrentUser = new UserModel();
            SubmitCommand = new RelayCommand(Submit);
        }   

        private void Submit(object obj)
        {
            MessageBox.Show("Profile Updated Successfully!");
            ProfileView newWindow = new ProfileView
            {
                DataContext = new ProfileModelView(_CurrentUser)
            };
            newWindow.Show();
            if (obj is Window currentWindow)
            {
                currentWindow.Close();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
