using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrolMVC.Controllers
{
    public class EmpController : Controller
    {
        IUserBL iuserBL;

        public EmpController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }
        public IActionResult GetAllEmployees()
        {
            List<EmpModel> lstEmployee = new List<EmpModel>();
            lstEmployee = iuserBL.GetAllEmployees().ToList();

            return View(lstEmployee);
        }

        [HttpGet]
        /*
           Polymorphism - Methos overloading
           [bind] bind model data with page
            ModelState.IsValid - check value are provided to all fields in model
                            Its by default came with mvc arch.
            
         */
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] EmpModel employee)
        {
            if (ModelState.IsValid)
            {
                iuserBL.AddEmployee(employee);
                return RedirectToAction("GetAllEmployees");
            }
            return View(employee);
        }
    }
}
