using Group1_Login.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Group1_Login.ViewModel
{
    class DashBoardViewModel
    {
        public ICommand  ProfileCommand{ get; }
        public ICommand CameraCommand { get; }

        public event Action ProfileProceed;
        public event Action CameraProceed;


        public DashBoardViewModel()
        {
            ProfileCommand = new RelayCommand(Profile);
            CameraCommand = new RelayCommand(Camera);
        }

        public void Profile(object parameter)
        {
            ProfileProceed?.Invoke();
            ProfileView newWindow = new ProfileView();
            newWindow.Show();
        }

        public void Camera(object parameter)
        {
            CameraProceed?.Invoke();
            CameraView newWindow = new CameraView();
            newWindow.Show();
        }
    }
}
