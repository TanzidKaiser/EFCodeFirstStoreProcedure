using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstStoreProcedure.Models;
using System.Data.SqlClient;

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
            try
            {
                SqlParameter param1 = new SqlParameter("@name", model.Name);
                SqlParameter param2 = new SqlParameter("@fname", model.FName);
                SqlParameter param3 = new SqlParameter("@salary", model.Salary);
                db.Database.ExecuteSqlCommand("exec sp_insertEmp @name, @fname, @salary", param1, param2, param3);
                return RedirectToAction("Index", true);
                // Response.Redirect("Index",true);

            }
            catch (Exception)
            {
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            SqlParameter p1 = new SqlParameter("@id", id);
            var data = db.Database.SqlQuery<Employee>("exec sp_getempbyid @id", p1).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            try
            {
                SqlParameter p1 = new SqlParameter("@id", model.ID);
                SqlParameter p2 = new SqlParameter("@name", model.Name);
                SqlParameter p3 = new SqlParameter("@fname", model.FName);
                SqlParameter p4 = new SqlParameter("@salary", model.Salary);

                db.Database.ExecuteSqlCommand("exec sp_update @name,@fname,@salary,@id", p2, p3, p4, p1);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            SqlParameter p = new SqlParameter("@id", id);
            var data = db.Database.SqlQuery<Employee>("exec sp_getempbyid @id", p).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, string name)
        {
            try
            {
                SqlParameter p = new SqlParameter("@id", id);
                db.Database.ExecuteSqlCommand("exec sp_delete @id", p);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
