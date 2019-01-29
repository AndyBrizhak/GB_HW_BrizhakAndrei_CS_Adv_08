using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppEmpDep.Models;

namespace WebAppEmpDep.Controllers
{
    public class DepController : ApiController
    {
        private List<Department> _deps = new List<Department>()
        {
            new Department {DepId = 1, DepName = "Приемная"},
            new Department {DepId = 2, DepName = "Прачечная"},
            new Department {DepId = 3, DepName = "Морг"}
        };

        public List<Department> GetAllDeps()
        {
            return _deps;
        }

        public IHttpActionResult GetDep(int id)
        {
            var dep = _deps.FirstOrDefault((p) => p.DepId == id);
            if (dep == null)
            {
                return NotFound();
            }
            return Ok(dep);
        }




    }
}
