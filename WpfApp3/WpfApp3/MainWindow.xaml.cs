using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp3.ViewModels;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        private void popUpMenu_Click(object sender, RoutedEventArgs e)
        {
            if (popUpColumn.Width == new GridLength(35))
            {
                popUpColumn.Width = new GridLength(160);
                imgMenu.Source =new BitmapImage(new Uri(@"../images/icons8-left-100.png", UriKind.Relative));
            }
            else
            {
                popUpColumn.Width = new GridLength(35);
                imgMenu.Source = new BitmapImage(new Uri(@"../images/icons8-menu-40.png",UriKind.Relative));
            }
        }
    }
}
