using AForge.Video;
using AForge.Video.DirectShow;
using Group1_Login.ViewModel;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

public class CameraViewModel : INotifyPropertyChanged
{
    private FilterInfoCollection? _videoDevices;
    private VideoCaptureDevice? _videoSource;

    public ICommand BackCommand { get; }
    public Action? CloseAction { get; set; }

    private BitmapImage? _cameraImage;
    public BitmapImage? CameraImage
    {
        get => _cameraImage;
        set
        {
            _cameraImage = value;
            OnPropertyChanged(nameof(CameraImage));
        }
    }

    public CameraViewModel()
    {
        BackCommand = new RelayCommand(ExecuteBack);
        StartCamera();
    }

    private void ExecuteBack(object? obj)
    {
        StopCamera();
        CloseAction?.Invoke();
    }

    public void StartCamera()
    {
        try
        {
            if (_videoSource != null && _videoSource.IsRunning)
                return;   // prevent double start

            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (_videoDevices.Count == 0)
            {
                MessageBox.Show("No camera found.");
                return;
            }

            _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _videoSource.NewFrame += VideoSource_NewFrame;
            _videoSource.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Camera error: " + ex.Message);
        }
    }

    private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        if (_videoSource == null || !_videoSource.IsRunning)
            return;

        using (Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone())
        {
            var image = ConvertBitmapToImage(bitmap);

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                CameraImage = image;
            }));
        }
    }

    private BitmapImage ConvertBitmapToImage(Bitmap bitmap)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Position = 0;

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();
            image.Freeze(); // prevent cross-thread issues

            return image;
        }
    }

    public void StopCamera()
    {
        var source = _videoSource;

        if (source != null)
        {
            source.NewFrame -= VideoSource_NewFrame;

            if (source.IsRunning)
            {
                source.SignalToStop();
                source.WaitForStop(); // safe because event removed first
            }

            source = null;
        }

        _videoSource = null;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}