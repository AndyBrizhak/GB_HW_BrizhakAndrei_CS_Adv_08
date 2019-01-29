using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEmpDep.Models
{
    /// <summary>
    /// Класс Работник в модели веб приложения
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string FName { get; set;}
        public string LName { get; set;}
        public string Age { get; set;}
        public int DepId { get; set;}
    }
}