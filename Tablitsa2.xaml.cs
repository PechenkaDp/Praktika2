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
    /// Логика взаимодействия для Tablitsa2.xaml
    /// </summary>
    public partial class Tablitsa2 : Window
    {
        int hours_int;
        int zatraty_int;
        int zarplata_int;
        workTableAdapter work = new workTableAdapter();
        public Tablitsa2()
        {

            InitializeComponent();
            workTabl.ItemsSource = work.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();

        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            string hours_s = hours.Text;
            string zatraty_s = zatraty.Text;
            string zarplata_s = zarplata.Text;
            hours_int = Convert.ToInt32(hours_s);
            zatraty_int = Convert.ToInt32(zatraty_s);
            zarplata_int = Convert.ToInt32(zarplata_s);
            work.InsertQuery(rabota_name.Text, zatraty_int, zarplata_int, hours_int);
            workTabl.ItemsSource = work.GetData();


        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            object idshnik = (workTabl.SelectedItem as DataRowView).Row[0];
            work.DeleteQuery(Convert.ToInt32(idshnik));
            workTabl.ItemsSource = work.GetData();
        }
    }
}
