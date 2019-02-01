using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppClientEmpDep
{
    public class Rep                                                           
    {
        /// <summary>
        /// Cтатический клиент для подключения через HttpClient
        /// </summary>
        static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Динамический список Работников
        /// </summary>
        public ObservableCollection<Employee> DbEmployees { get; set; }
        public ObservableCollection<Department> DbDepartments { get; set; }

        /// <summary>
        /// Класс Репозиторий для описания списков Работников и Департаментов
        /// </summary>
        public Rep()
        {
            DbEmployees = new ObservableCollection<Employee>();
            DbDepartments = new ObservableCollection<Department>();

            string urlEmp = @"http://localhost:54926/api/Emp";
            string urlDep = @"http://localhost:54926/api/Dep";

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //var resultEmp = httpClient.GetStringAsync(urlEmp).Result;

            ////Console.WriteLine(resultEmp);

            //(urlEmp + "api/api/Emp");

            //var resultDep = httpClient.GetStringAsync(urlDep).Result;

            ////Console.WriteLine(resultDep);
            //DbEmployees = null;
            DbDepartments = null;
            HttpResponseMessage responsDepResult = httpClient.GetAsync(urlDep).Result;
            var taskDepRes = responsDepResult.Content.ReadAsAsync<ObservableCollection<Department>>();
            DbDepartments = taskDepRes.Result;
           
            //DbEmployees =  GetEmpAsync(urlEmp).Result; //Получение результата запроса списка работников из вебприложения


            //DbDepartments = GetDepAsync(urlDep).Result; //Получение результата запроса списка работников из вебприложения
        }

        private ObservableCollection<Employee> GetEmp(string urlEmp)
        {
            var resp = httpClient.GetAsync(urlEmp).Result;
            var task = resp.Content.ReadAsAsync<ObservableCollection<Employee>>();
            var res = task.Result;
        }

        /// <summary>
        /// Метод получения списка  департаментов из веб сервиса
        /// </summary>
        /// <param name="urlDep"></param>
        /// <returns></returns>
        private async Task<ObservableCollection<Department>> GetDepAsync(string urlDep)
        {
            ObservableCollection<Department> ColDep = null;
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(urlDep);
                if (response.IsSuccessStatusCode)
                {
                    ColDep = await response.Content.ReadAsAsync<ObservableCollection<Department>>();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Не найден список Департаментов на веб ресурсе");
                throw;
            }
            return ColDep;
        }

        /// <summary>
        /// Метод получения списка работников из веб сервиса
        /// </summary>
        /// <param name="urlEmp">Параметры запроса к веб прилжению</param>
        /// <returns></returns>
        private async Task <ObservableCollection<Employee>> GetEmpAsync (string urlEmp)
        {
            ObservableCollection<Employee> ColEmp = null;
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(urlEmp);
                if (response.IsSuccessStatusCode)
                {
                    ColEmp = await response.Content.ReadAsAsync <ObservableCollection<Employee>>();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Не найден список Работников на веб ресурсе");
                throw;
            }
            return ColEmp;
        }


        /// <summary>
        /// Добавляет Департамент 
        /// </summary>
        /// <param name="NameDep">Имя нового департамента</param>
        public void AddDep(string nameDep)
        {
            DbDepartments.Add(new Department(nameDep, DbDepartments.Count + 1));

        }

        /// <summary>
        /// Удаление департамента и всех его сотрудников
        /// </summary>
        /// <param name="id">Идентификатор департамента</param>
        public void DelDep(int id)
        {
            for (int i = DbEmployees.Count - 1; i >= 0; i--)
            {
                if (DbEmployees[i].DepID == id)
                {
                    DbEmployees.RemoveAt(i);
                }
            }

            for (int i = DbDepartments.Count - 1; i >= 0; i--)
            {
                if (DbDepartments[i].DepId == id) DbDepartments.RemoveAt(i);
            }
        }

        /// <summary>
        /// Добавление работника в коллекцию
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="age"></param>
        /// <param name="strAge"></param>
        /// <param name="depId"></param>
        public void AddEmp(string fName, string lName, string strAge, int depId)
        {
            //var age = int.Parse(strAge);
            DbEmployees.Add(new Employee(fName, lName, strAge, depId));

        }


        /// <summary>
        /// Удаляет работника из коллекции
        /// </summary>
        /// <param name="selEmployee"></param>
        public void DelEmp(Employee selEmployee)
        {
            if (DbEmployees.Count == 0) return;
            if (!DbEmployees.Contains(selEmployee)) return;
            //DbEmployees.RemoveAt(id);
            DbEmployees.Remove(selEmployee);
        }
    }
}
