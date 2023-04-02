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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Praktika_2.pract1DataSetTableAdapters;

namespace Praktika_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        int Age_int;
        int rabota_int;
        int nalogi_int;
        int itog_int;
        ZitelTableAdapter Zitel = new ZitelTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            ZitelTabl.ItemsSource = Zitel.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tablitsa3 tablitsa3 = new Tablitsa3();
            tablitsa3.Show();
            Close();


        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Tablitsa2 tablitsa2 = new Tablitsa2();
            tablitsa2.Show();
            Close();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            string age_s = Age.Text;
            string nalogi_s = nalogi.Text;
            string itog_s = itog.Text;
            string rabota_s = Rabota.Text;
            Age_int = Convert.ToInt32(age_s);
            rabota_int = Convert.ToInt32(rabota_s);
            nalogi_int = Convert.ToInt32(nalogi_s);
            itog_int = Convert.ToInt32(itog_s);
            Zitel.InsertQuery(nameZ.Text, Familia.Text, Age_int, rabota_int, nalogi_int, itog_int);
            ZitelTabl.ItemsSource = Zitel.GetData();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object idshnik = (ZitelTabl.SelectedItem as DataRowView).Row[0];
            MessageBox.Show(idshnik.ToString());
        }

        private void ZitelTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Ydalenie_click(object sender, RoutedEventArgs e)
        {
            object idshnik = (ZitelTabl.SelectedItem as DataRowView).Row[0];
            Zitel.DeleteQuery(Convert.ToInt32(idshnik));
            ZitelTabl.ItemsSource = Zitel.GetData();

        }
    }
}
