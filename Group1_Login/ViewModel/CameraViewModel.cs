using AForge.Video;
using AForge.Video.DirectShow;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;
using System;

public class CameraViewModel : INotifyPropertyChanged
{
    private FilterInfoCollection _videoDevices;
    private VideoCaptureDevice _videoSource;

    private BitmapImage _cameraImage;
    public BitmapImage CameraImage
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
        StartCamera();
    }

    private void StartCamera()
    {
        _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        if (_videoDevices.Count > 0)
        {
            _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _videoSource.NewFrame += VideoSource_NewFrame;
            _videoSource.Start();
        }
    }

    private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        using (Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone())
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                CameraImage = ConvertBitmapToImage(bitmap);
            });
        }
    }

    private BitmapImage ConvertBitmapToImage(Bitmap bitmap)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            return image;
        }
    }

    public void StopCamera()
    {
        if (_videoSource != null && _videoSource.IsRunning)
        {
            _videoSource.SignalToStop();
            _videoSource.WaitForStop();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}