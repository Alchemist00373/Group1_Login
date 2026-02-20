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
using System.ComponentModel;


namespace Group1_Login.View
{
    /// <summary>
    /// Interaction logic for CameraView.xaml
    /// </summary>
    public partial class CameraView : Window
    {
        private CameraViewModel _viewModel;

        public CameraView()
        {
            InitializeComponent();
            _viewModel = new CameraViewModel();
            _viewModel.CloseAction = Close;
            DataContext = _viewModel;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _viewModel.StopCamera();
            base.OnClosing(e);
        }
    }
}
