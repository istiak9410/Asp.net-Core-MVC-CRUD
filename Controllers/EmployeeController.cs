using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectMvcAspCore.Models;


namespace ProjectMvcAspCore.Controllers
{

    public class EmployeeController : Controller
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();
        // GET: Employee

        public IActionResult Index()
        {
            List<EmployeeInfo> emplist = new List<EmployeeInfo>();
            emplist = employeeDAL.GetAllEmployee().ToList();
            return View(emplist);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = employeeDAL.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeInfo objEmp)
        {
            if (ModelState.IsValid)
            {
               employeeDAL.AddEmployee(objEmp);
                return RedirectToAction("Index");
            }
            return View(objEmp);
        }

        // GET: Employee/Edit/5

        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            EmployeeInfo emp = employeeDAL.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] EmployeeInfo objEmp)
        {
           if(id == null)
           {
                return NotFound();
           }

            if (ModelState.IsValid)
            {
                employeeDAL.UpdateEmployee(objEmp);
                return RedirectToAction("Index");
            }
            return View(objEmp);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = employeeDAL.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int? id)
        {
            employeeDAL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}