using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppEmpDep.Models;

namespace WebAppEmpDep.Controllers
{
    /// <summary>
    /// Класс - контроллер для списка Сотрудников
    /// </summary>
    public class EmpController : ApiController
    {
        /// <summary>
        /// Список сотрудников
        /// </summary>
        //private List<Employee> _emps = new List<Employee>()
        //{
        //    new Employee {Id = 1, FName = "Олеся", LName = "Пупкина", Age ="28", DepId = 1},
        //    new Employee{Id = 2, FName = "Олег", LName = "Ложкин", Age ="38", DepId = 2},
        //    new Employee{Id = 3, FName = "Крис", LName = "Рыбкин", Age ="88", DepId = 3}
        //};

        private DataEmp _dataEmp = new DataEmp();


        //public List<Employee> GetAllEmployees()
        //{
        //    return _emps;
        //}

        /// <summary>
        /// Метод возвращает список всех работников
        /// </summary>
        /// <returns></returns>
        [Route("getlist")]
        public List<Employee> Get() => _dataEmp.Get();



      
        //public IHttpActionResult GetEmployee(int id)
        //{
        //    var emp = _emps.FirstOrDefault((p) => p.Id == id);
        //    if (emp == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(emp);
        //}

        /// <summary>
        /// Метод возвращает иформацию о работнике
        /// </summary>
        /// <param name="id">Идентификатор работника в базе данных</param>
        /// <returns></returns>
        [Route("getlist/{id}")]
        public Employee Get(int id) => _dataEmp.Get(id);




        //public List<Employee> GetDepEmployees(Employee[] emps, int depId)
        //{
        //    if (emps.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(emps));
        //    var empDep = new List<Employee>();
        //    foreach (Employee v in emps)
        //    {
        //        if (v.DepId == depId)
        //        {
        //            empDep.Add(v);
        //        }
        //    }
        //    return empDep;
        //}

        /// <summary>
        /// Метод возвращает список работников из одного департамента
        /// </summary>
        /// <param name="dep">Идентификатор департамента</param>
        /// <returns></returns>
        [Route("getlist/{dep}")]
        public List<Employee> GetEmpByIdDep(int emp) => _dataEmp.GetEmpByIdDep(emp);

        //public IHttpActionResult GetDepEmpHttpActionResult(Employee[] emps, int depId)
        //{
        //    if (emps.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(emps));
        //    var empDep = new List<Employee>();
        //    foreach (Employee v in emps)
        //    {
        //        if (v.DepId == depId)
        //        {
        //            empDep.Add(v);
        //        }
        //    }

        //    if (empDep.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(empDep);
        //}

        /// <summary>
        /// Метод добавления Департамента в БД
        /// </summary>
        /// <param name="value">Работник, добавляемый в БД</param>
        /// <returns></returns>
        [Route("addemp")]
        public HttpResponseMessage Post([FromBody] Employee value)
        {
            return Request.CreateResponse(_dataEmp.AddEmp(value) ? HttpStatusCode.Created : HttpStatusCode.BadRequest);
        }


    }
}
