using Group1_Login.Model;
using Group1_Login.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Group1_Login.ViewModel
{
    public class DashBoardViewModel
    {
        private UserModel _currentUser;

        public ICommand ProfileCommand { get; }
        public ICommand CameraCommand { get; }

        public DashBoardViewModel(UserModel currentUser)
        {
            _currentUser = currentUser;

            ProfileCommand = new RelayCommand(Profile);
            CameraCommand = new RelayCommand(Camera);
        }

        private void Profile(object parameter)
        {
            ProfileView newWindow = new ProfileView
            {
                DataContext = new ProfileModelView(_currentUser)
            };
            newWindow.Show();
        }

        private void Camera(object parameter)
        {
            CameraView newWindow = new CameraView();
            newWindow.Show();
        }
    }
}
