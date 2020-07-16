using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandsOn3;
using Microsoft.EntityFrameworkCore.Internal;
using HandsOn3.Controllers;
using System.Web;
using System.Net;
using System.Net.Http;

namespace HandsOn3.Controllers

    

{

    public class EmployeeController : Controller
    {

        public object vs { get; private set; }
        string[] str = { "java", "c++" };
        string[] str1 = { ".net", "programming" };

        private List<Employee> GetStandardEmployees()
        {
          
            List<Employee> em = new List<Employee>()
            {
                new Employee{Id=1,Name="Mansi",Salary=1000,DOB="18/09/1999",Permanent=true,Department=new Department{deptId=201,deptName="CSE"},Skills=new List<Skill>(){ new Skill() { vs  =str.ToList() }} },

                new Employee{Id=2,Name="Soni",Salary=2000,DOB="19/09/1999",Permanent=true,Department=new Department{deptId=202,deptName="commerce"},Skills=new List<Skill>(){ new Skill() { vs=str1.ToList()} } }

            };
            return em;

        }
        

        // GET: Employee
        public ActionResult<IEnumerable<Employee>> Index()
        {
            
            
            
           
            using (var client=new WebClient())
            {
                
                return GetStandardEmployees();
            }
            
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}