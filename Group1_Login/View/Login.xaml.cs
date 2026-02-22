using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using static System.Net.Mime.MediaTypeNames;

< Window x: Class = "Group1_Login.View.DashBoardView"
        xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns: x = "http://schemas.microsoft.com/winfx/2006/xaml"
        Title = "Dashboard"
        Height = "600"
        Width = "1000"
        WindowStartupLocation = "CenterScreen"
        Background = "#1C352D" >

    < Grid Margin = "20" >

        < Grid.ColumnDefinitions >
            < ColumnDefinition Width = "2*" />
            < ColumnDefinition Width = "3*" />
        </ Grid.ColumnDefinitions >

        < !--CAMERA PANEL-- >
        < Border Grid.Column = "0"
                Background = "#254336"
                CornerRadius = "20"
                Padding = "20"
                Margin = "0,0,15,0" >

            < StackPanel >
                < TextBlock Text = "LIVE CAMERA"
                           FontSize = "22"
                           FontWeight = "Bold"
                           Foreground = "White"
                           Margin = "0,0,0,15" />

                < Border Height = "400"
                        Background = "#1C352D"
                        CornerRadius = "15"
                        BorderBrush = "#38EF7D"
                        BorderThickness = "2" >

                    < TextBlock Text = "Camera Feed"
                               Foreground = "Gray"
                               HorizontalAlignment = "Center"
                               VerticalAlignment = "Center" />
                </ Border >
            </ StackPanel >
        </ Border >

        < !--INFO PANEL-- >
        < Border Grid.Column = "1"
                Background = "#254336"
                CornerRadius = "20"
                Padding = "30" >

            < StackPanel >

                < TextBlock Text = "PERSONAL INFORMATION"
                           FontSize = "24"
                           FontWeight = "Bold"
                           Foreground = "White"
                           Margin = "0,0,0,25" />

                < TextBox Height = "40" Margin = "0,5"
                         PlaceholderText = "Full Name"
                         Text = "{Binding User.FullName}" />

                < TextBox Height = "40" Margin = "0,5"
                         PlaceholderText = "Age"
                         Text = "{Binding User.Age}" />

                < TextBox Height = "40" Margin = "0,5"
                         PlaceholderText = "Address"
                         Text = "{Binding User.Address}" />

                < TextBox Height = "40" Margin = "0,5"
                         PlaceholderText = "Contact"
                         Text = "{Binding User.Contact}" />

                < TextBox Height = "40" Margin = "0,5,0,20"
                         PlaceholderText = "Email"
                         Text = "{Binding User.Email}" />

                < Button Content = "SAVE"
                        Height = "45"
                        FontWeight = "Bold"
                        Foreground = "White"
                        Background = "#38EF7D"
                        Command = "{Binding SaveCommand}" />

            </ StackPanel >
        </ Border >
    </ Grid >
</ Window >
