using Group1_Login.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Group1_Login.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            var vm = new LoginViewModel();
            vm.LoginSucceeded += OpenDashboard;

            DataContext = vm;
        }

        private void OpenDashboard()
        {
            DashBoardView dashboard = new DashBoardView();
            dashboard.Show();
            this.Close();
        
    }
    }
}
