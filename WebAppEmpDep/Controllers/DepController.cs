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
    /// Класс - контроллер для взаимодействия с БД Департаментов
    /// </summary>
    public class DepController : ApiController
    {
        //private List<Department> _deps = new List<Department>()
        //{
        //    new Department {DepId = 1, DepName = "Приемная"},
        //    new Department {DepId = 2, DepName = "Прачечная"},
        //    new Department {DepId = 3, DepName = "Морг"}
        //};

        private DataDep _dataDep = new DataDep();



        //public List<Department> GetAllDeps()
        //{
        //    return _deps;
        //}

        /// <summary>
        /// Метод получения списка Департаментов из БД в контроллере
        /// </summary>
        /// <returns></returns>
        public List<Department> Get() => _dataDep.GetList();

        /// <summary>
        ///  Метод получения Департамента из БД в контроллере
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department Get(int id) => _dataDep.GetDepById(id);

        //public IHttpActionResult GetDep(int id)
        //{
        //    var dep = _deps.FirstOrDefault((p) => p.DepId == id);
        //    if (dep == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(dep);
        //}

        /// <summary>
        /// Метод добавления Департамента в БД
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] Department value)
        {
            if (_dataDep.AddDep(value))
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }



    }
}
