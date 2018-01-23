using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstStoreProcedure.Models;
namespace EFCodeFirstStoreProcedure.Controllers
{
    public class HomeController : Controller
    {
        StoreProcedureDBEntities db = new StoreProcedureDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Database.SqlQuery<Employee>("exec sp_getEmp");
            return View(data);
        }  
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee model)
        {
            return View();
        }
    }
}
