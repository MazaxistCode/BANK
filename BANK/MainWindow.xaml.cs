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

namespace BANK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            Transaction form = new Transaction();
            Visibility = Visibility.Hidden;
            form.ShowDialog();
            Visibility = Visibility.Visible;
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Report form = new Report();
            Visibility = Visibility.Hidden;
            form.ShowDialog();
            Visibility = Visibility.Visible;
        }
    }
}
