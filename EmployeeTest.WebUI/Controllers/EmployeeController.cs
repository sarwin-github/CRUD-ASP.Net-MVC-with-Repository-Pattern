using EmployeeTest.Domain.Abstract;
using EmployeeTest.Domain.Entities;
using EmployeeTest.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EmployeeTest.WebUI.Controllers
{
   
    public class EmployeeController : Controller
    {
        IEmployeeRepository repository;    
        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ViewResult Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                var employee = repository.Employees
                    .Where(e => e.FullName.ToUpper().Contains(searchString.ToUpper()));
                return View(employee);
            }
            return View(repository.Employees);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repository.SaveEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        [HttpGet]
        public ViewResult Details(int? id)
        {
            Employee employee = repository.Employees.FirstOrDefault(x => x.EmployeeID == id);
            return View(employee);
        }

        [HttpGet]
        public ViewResult Edit(int? id)
        {
            Employee employee = repository.Employees.FirstOrDefault(x => x.EmployeeID == id);
            return View(employee);
        }

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            Employee employee = repository.Employees.FirstOrDefault(x => x.EmployeeID == id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            Employee employee = repository.Employees.FirstOrDefault(x => x.EmployeeID == id);
            repository.DeleteEmployee(employee.EmployeeID);
            return RedirectToAction("Index");
        }
    }
}