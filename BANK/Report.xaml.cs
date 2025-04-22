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
using System.Windows.Shapes;

namespace BANK
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
            DataTransaction.ItemsSource = DB.BANKEntities.GetContext().Financial_transactions.ToList();
        }
        public void UpdateDB()
        {
            List<DB.Financial_transactions> financial_Transactions = new List<DB.Financial_transactions>();
            if ((bool)WaneBox.IsChecked)
                financial_Transactions.AddRange(DB.BANKEntities.GetContext().Financial_transactions.Where(finTrans => finTrans.Money <= 0));
            if ((bool)(ProfitBox != null ? ProfitBox.IsChecked : true))
                financial_Transactions.AddRange(DB.BANKEntities.GetContext().Financial_transactions.Where(finTrans => finTrans.Money > 0));
            DataTransaction.ItemsSource = financial_Transactions;
        }
        private void WaneBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void ProfitBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void ProfitBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void WaneBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
    }
}
