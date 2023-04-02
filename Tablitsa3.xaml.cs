using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
using Praktika_2.pract1DataSetTableAdapters;

namespace Praktika_2
{
    /// <summary>
    /// Логика взаимодействия для Tablitsa3.xaml
    /// </summary>
    public partial class Tablitsa3 : Window
    {
        int ZKH_int;
        int nalog_int;
        paymentsTableAdapter payments = new paymentsTableAdapter();
        public Tablitsa3()
        {
            InitializeComponent();
            paymentslTabl.ItemsSource = payments.GetData();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow  main= new MainWindow();
            main.Show();
            Close();

        }

        private void ydalenie_click(object sender, RoutedEventArgs e)
        {
            object idshnik = (paymentslTabl.SelectedItem as DataRowView).Row[0];
            payments.DeleteQuery(Convert.ToInt32(idshnik));
            paymentslTabl.ItemsSource = payments.GetData();
        }

        private void Dobavlenie_click(object sender, RoutedEventArgs e)
        {
            string nalog_s = nalog.Text;
            string ZKH_s = ZKH.Text;
            ZKH_int = Convert.ToInt32(ZKH_s);
            nalog_int = Convert.ToInt32(nalog_s);
            payments.InsertQuery(mesto.Text, ZKH_int, nalog_int);
            paymentslTabl.ItemsSource = payments.GetData();
        }
    }
}
