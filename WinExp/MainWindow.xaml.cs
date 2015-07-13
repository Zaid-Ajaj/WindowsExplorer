using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Interop;

namespace WinExp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == true)
            //{
            //    Bitmap bmp = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
            //    IntPtr hBitmap = bmp.GetHbitmap();
            //    ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            //    bmp.Dispose();
            //    img.Source = wpfBitmap;
            //}
            
        }

       
        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true) pnlItems.ItemsSource =  DataManeger.GetItems(System.IO.Path.GetDirectoryName(ofd.FileName));
        }

        private void View_MyComputer(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.GetDrives();
        }

        private void Open(object sender, MouseButtonEventArgs e)
        {
            if (pnlItems.SelectedItems.Count == 1)
            {
                FileInformation info = pnlItems.SelectedItems[0] as FileInformation;
                if (info.IsFolder) pnlItems.ItemsSource = DataManeger.GetItems(info.FullPath);
                else if (info.IsComputer) pnlItems.ItemsSource = DataManeger.GetDrives();
                else
                {
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(info.FullPath);
                        }
                        catch { }
                    }
                }
               
            }
        }

        private void Desktop(object sender, RoutedEventArgs e)
        {
            pnlItems.ItemsSource = DataManeger.Desktop();
        }

    }
}
