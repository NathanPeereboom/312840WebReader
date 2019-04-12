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

namespace _312840WebReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int month;
        double total;
        double monthSales;
        double greatestSales;
        int greatestSalesMonth;
        double lowestSales;
        int lowestSalesMonth;

        private void btn2017_Click(object sender, RoutedEventArgs e)
        {
            showMonthlySales("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2017.txt");
        }

        private void btn2018_Click(object sender, RoutedEventArgs e)
        {
            showMonthlySales("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2018.txt");
        }

        public void showMonthlySales (string url)
        {
            lblOutput.Content = "";
            System.Net.WebClient webClient = new System.Net.WebClient();
            System.IO.StreamReader streamReader = new System.IO.StreamReader
                    (webClient.OpenRead(url));
            month = 0;

            if ((bool)rbJanuary.IsChecked) month = 1;
            if ((bool)rbFebruary.IsChecked) month = 2;
            if ((bool)rbMarch.IsChecked) month = 3;
            if ((bool)rbApril.IsChecked) month = 4;
            if ((bool)rbMay.IsChecked) month = 5;
            if ((bool)rbJune.IsChecked) month = 6;
            if ((bool)rbJuly.IsChecked) month = 7;
            if ((bool)rbAugust.IsChecked) month = 8;
            if ((bool)rbSeptember.IsChecked) month = 9;
            if ((bool)rbOctober.IsChecked) month = 10;
            if ((bool)rbNovember.IsChecked) month = 11;
            if ((bool)rbDecember.IsChecked) month = 12;
            for (int i = 0; i < month; i++)
            {
                streamReader.ReadLine();
            }
            lblOutput.Content = "$" + streamReader.ReadLine();
            if (month == 0) lblOutput.Content = "Please select a month";
            streamReader.Close();
        }

        private void btnSummary17_Click(object sender, RoutedEventArgs e)
        {
            summary("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2017.txt");
            greatest("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2017.txt");
            lowest("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2017.txt");
        }

        private void btnSummary18_Click(object sender, RoutedEventArgs e)
        {
            summary("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2018.txt");
            greatest("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2018.txt");
            lowest("https://raw.githubusercontent.com/IanMcT/April8_2019Assignment/master/2018.txt");
        }

        public void summary (string url)
        {
            lblOutput.Content = "";
            System.Net.WebClient webClient = new System.Net.WebClient();
            System.IO.StreamReader streamReader = new System.IO.StreamReader
                    (webClient.OpenRead(url));
            total = 0;
            monthSales = 0;
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                double.TryParse(streamReader.ReadLine(), out monthSales);
                total += monthSales;
            }
            streamReader.Close();
            lblOutput.Content = "Total sales: $" + total + Environment.NewLine +
                "Average sales: $" + total/12;
        }

        public void greatest (string url)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            System.IO.StreamReader streamReader = new System.IO.StreamReader
                    (webClient.OpenRead(url));
            monthSales = 0;
            greatestSales = 0;
            month = 0;
            greatestSalesMonth = 0;
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                double.TryParse(streamReader.ReadLine(), out monthSales);
                month++;
                if (monthSales > greatestSales)
                {
                    greatestSales = monthSales;
                    greatestSalesMonth = month;
                }
            }
            streamReader.Close();
            lblOutput.Content += Environment.NewLine + "Highest Sales: $" + greatestSales;
            if (greatestSalesMonth == 1) lblOutput.Content += " (January)";
            if (greatestSalesMonth == 2) lblOutput.Content += " (February)";
            if (greatestSalesMonth == 3) lblOutput.Content += " (March)";
            if (greatestSalesMonth == 4) lblOutput.Content += " (April)";
            if (greatestSalesMonth == 5) lblOutput.Content += " (May)";
            if (greatestSalesMonth == 6) lblOutput.Content += " (June)";
            if (greatestSalesMonth == 7) lblOutput.Content += " (July)";
            if (greatestSalesMonth == 8) lblOutput.Content += " (August)";
            if (greatestSalesMonth == 9) lblOutput.Content += " (September)";
            if (greatestSalesMonth == 10) lblOutput.Content += " (October)";
            if (greatestSalesMonth == 11) lblOutput.Content += " (November)";
            if (greatestSalesMonth == 12) lblOutput.Content += " (December)";
        }

        public void lowest(string url)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            System.IO.StreamReader streamReader = new System.IO.StreamReader
                    (webClient.OpenRead(url));
            monthSales = 0;
            lowestSales = 999999999;
            month = 0;
            lowestSalesMonth = 0;
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                double.TryParse(streamReader.ReadLine(), out monthSales);
                month++;
                if (monthSales < lowestSales)
                {
                    lowestSales = monthSales;
                    lowestSalesMonth = month;
                }
            }
            streamReader.Close();
            lblOutput.Content += Environment.NewLine + "Lowest Sales: $" + lowestSales;
            if (lowestSalesMonth == 1) lblOutput.Content += " (January)";
            if (lowestSalesMonth == 2) lblOutput.Content += " (February)";
            if (lowestSalesMonth == 3) lblOutput.Content += " (March)";
            if (lowestSalesMonth == 4) lblOutput.Content += " (April)";
            if (lowestSalesMonth == 5) lblOutput.Content += " (May)";
            if (lowestSalesMonth == 6) lblOutput.Content += " (June)";
            if (lowestSalesMonth == 7) lblOutput.Content += " (July)";
            if (lowestSalesMonth == 8) lblOutput.Content += " (August)";
            if (lowestSalesMonth == 9) lblOutput.Content += " (September)";
            if (lowestSalesMonth == 10) lblOutput.Content += " (October)";
            if (lowestSalesMonth == 11) lblOutput.Content += " (November)";
            if (lowestSalesMonth == 12) lblOutput.Content += " (December)";
        }
    }
}