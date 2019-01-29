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
        public Rep dbEmpDep;

        public MainWindow()
        {
            InitializeComponent();

            string urlEmp = @"http://localhost:54926/api/Emp";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            var resultEmp = httpClient.GetStringAsync(urlEmp).Result;

            //Console.WriteLine(resultEmp);

            string urlDep = @"http://localhost:54926/api/Dep";
            var resultDep = httpClient.GetStringAsync(urlDep).Result;
            //Console.WriteLine(resultDep);


            //var cl = new WebClient() {Encoding = Encoding.UTF8};
            //Console.WriteLine(cl.DownloadString(url));

            InitializeComponent();
            dbEmpDep = new Rep();
            MainGrid.DataContext = dbEmpDep;
            this.DataContext = dbEmpDep;

            //dbEmpDep.AddDep("Приемная");
            //dbEmpDep.AddDep("Прачечная");
            //dbEmpDep.AddDep("Морг");
            //dbEmpDep.AddEmp("Василий", "Афанасьев", 25.ToString(), 1);
            //dbEmpDep.AddEmp("Федор", "Ивлев", 25.ToString(), 1);
            //dbEmpDep.AddEmp("Тамара", "Иванова", 32.ToString(), 2);
            //dbEmpDep.AddEmp("Валентина", "Кошелева", 32.ToString(), 2);
            //dbEmpDep.AddEmp("Василий", "Пупкин", 48.ToString(), 3);
            //dbEmpDep.AddEmp("Иван", "Ложкин", 48.ToString(), 3);

            

            DepEditBtn.Click += delegate
            {
                new EditDepWindow((DepCombobox.SelectedItem as Department).DepId, dbEmpDep).ShowDialog();
            };

            ListEmp.MouseDoubleClick += ListEmp_MouseDoubleClick;
        }

        private void ListEmp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            new EditEmpWindow((ListEmp.SelectedItem as Employee).GetHashCode(), dbEmpDep).ShowDialog();
        }

        private void DepCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            RefreshListEmp();
        }

        /// <summary>
        /// Обновление списка сотрудников в департаменте
        /// </summary>
        private void RefreshListEmp()
        {
            ListEmp.ItemsSource = dbEmpDep.DbEmployees.Where(w => w.DepID == (DepCombobox.SelectedValue as Department)?.DepId);
        }

        private void ButtonDelDep_Click(object sender, RoutedEventArgs e)
        {
            dbEmpDep.DelDep((DepCombobox.SelectedValue as Department).DepId);
            RefreshListEmp();
        }

        private void ButtonAddDep_Click(object sender, RoutedEventArgs e)
        {

            new AddDepWindow(dbEmpDep).ShowDialog();
            RefreshListEmp();
        }

        private void ButtonAddEmp_Click(object sender, RoutedEventArgs e)
        {

            new AddEmpWindow(dbEmpDep, (DepCombobox.SelectedItem as Department).DepId).ShowDialog();
            RefreshListEmp();
        }

        private void ButtonDelEmp_Click(object sender, RoutedEventArgs e)
        {

            Employee selEmployee = ListEmp.SelectedItem as Employee;
            dbEmpDep.DelEmp(selEmployee);
            RefreshListEmp();
        }
    }
}
