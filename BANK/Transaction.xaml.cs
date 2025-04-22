using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        public Transaction()
        {
            InitializeComponent();
            DataTransaction.ItemsSource = DB.BANKEntities.GetContext().Financial_transactions.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(NameBox.Text) && string.IsNullOrEmpty(MoneyBox.Text)) && Calendar.SelectedDate != null)
            {
                if(int.TryParse(MoneyBox.Text, out int result))
                {
                    DB.BANKEntities.GetContext().Financial_transactions.Add(new DB.Financial_transactions()
                    {
                        Date = (DateTime)Calendar.SelectedDate,
                        Name = NameBox.Text,
                        Money = result
                    });
                    DB.BANKEntities.GetContext().SaveChanges();
                    DataTransaction.ItemsSource = DB.BANKEntities.GetContext().Financial_transactions.ToList();
                }
                else
                    MessageBox.Show("Введите числа в поле \"Деньги\"");
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(NameBox.Text) && string.IsNullOrEmpty(MoneyBox.Text))
                && Calendar.SelectedDate != null && DataTransaction.SelectedItem is DB.Financial_transactions)
            {
                if (int.TryParse(MoneyBox.Text, out int result))
                {
                    var item = DataTransaction.SelectedItem as DB.Financial_transactions;
                    item.Date = (DateTime)Calendar.SelectedDate;
                    item.Name = NameBox.Text;
                    item.Money = result;
                    DB.BANKEntities.GetContext().SaveChanges();
                    DataTransaction.ItemsSource = DB.BANKEntities.GetContext().Financial_transactions.ToList();
                }
                else
                    MessageBox.Show("Введите числа в поле \"Деньги\"");
            }
            else
                MessageBox.Show("Заполните все поля и выберите транзакцию");
        }

        private void RemButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataTransaction.SelectedItem is DB.Financial_transactions)
            {
                DB.BANKEntities.GetContext().Financial_transactions.Remove(DataTransaction.SelectedItem as DB.Financial_transactions);
                DB.BANKEntities.GetContext().SaveChanges();
                DataTransaction.ItemsSource = DB.BANKEntities.GetContext().Financial_transactions.ToList();
            }
            else
                MessageBox.Show("Выберите транзакцию");
        }

        private void DataTransaction_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataTransaction.SelectedItem is DB.Financial_transactions)
            {
                var item = DataTransaction.SelectedItem as DB.Financial_transactions;
                MoneyBox.Text = item.Money.ToString();
                NameBox.Text = item.Name;
                Calendar.DisplayDate = item.Date;
                Calendar.SelectedDate = item.Date;
            }
        }
    }
}
