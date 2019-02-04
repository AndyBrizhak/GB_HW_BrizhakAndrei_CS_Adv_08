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
            DbEmployees = null;
            DbDepartments = null;
            Task<ObservableCollection<Department>> taskDepRes = GetDep(urlDep);
            DbDepartments = taskDepRes.Result;
            DbEmployees = GetEmp(urlEmp).Result;
        }

        /// <summary>
        /// Получение результата запроса списка департаментов из вебприложения
        /// </summary>
        /// <param name="urlDep"></param>
        /// <returns></returns>
        private static Task<ObservableCollection<Department>> GetDep(string urlDep)
        {
            var responsDepResult = httpClient.GetAsync(urlDep).Result;
            var taskDepRes = responsDepResult.Content.ReadAsAsync<ObservableCollection<Department>>();
            return taskDepRes;
        }

        /// <summary>
        /// Получение результата запроса списка работников из вебприложения
        /// </summary>
        /// <param name="urlEmp"></param>
        /// <returns></returns>
        private static Task<ObservableCollection<Employee>> GetEmp(string urlEmp)
        {
            var responsEmpResult = httpClient.GetAsync(urlEmp).Result;
            var taskEmpRes = responsEmpResult.Content.ReadAsAsync<ObservableCollection<Employee>>();
            return taskEmpRes;
        }

        //private Task<ObservableCollection<Employee>> GetEmp(string urlEmp)
        //{
        //    Task<ObservableCollection<Employee>> task = null;
        //    try
        //    {
        //        var resp = httpClient.GetAsync(urlEmp);
        //        if (resp.IsCompleted)
        //        {
        //            var respResult = resp.Result;
        //            task = respResult.Content.ReadAsAsync<ObservableCollection<Employee>>();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //       Console.WriteLine("Не найден список Работников на веб ресурсе: {0}", e.ToString());
        //        throw;
        //    }
        //    return task;
        //}


        /// <summary>
        /// Добавляет Департамент 
        /// </summary>
        /// <param name="NameDep">Имя нового департамента</param>
        public void AddDep(string nameDep)
        {
            DbDepartments.Add(new Department(nameDep, DbDepartments.Count + 1));

        }

        /// <summary>
        /// Редактирует название департамента
        /// </summary>
        /// <param name="iDep"></param>
        /// <param name="text"></param>
        public void EdDepp(int iDep, string text)
        {
            DbDepartments[iDep - 1].DepName = text;
            
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
