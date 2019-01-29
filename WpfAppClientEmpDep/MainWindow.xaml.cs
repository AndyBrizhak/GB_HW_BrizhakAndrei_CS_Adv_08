using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace WpfAppClientEmpDep
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = @"http://localhost:54926/api/Employee/1";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            var r = httpClient.GetStringAsync(url).Result;

            Console.WriteLine(r);

            //var cl = new WebClient() {Encoding = Encoding.UTF8};
            //Console.WriteLine(cl.DownloadString(url));
        }
    }
}
