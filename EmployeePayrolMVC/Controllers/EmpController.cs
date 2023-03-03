using BusinessLayer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrolMVC.Controllers
{
   // [Authorize]
   
    public class EmpController : Controller
    {
        IEmpBL iuserBL;
        private readonly IHttpContextAccessor context;
        public EmpController(IEmpBL iuserBL)
        {
            this.iuserBL = iuserBL;

        }
        
        //[HttpGet]
        //For Get all employee
        public IActionResult GetAllEmployees()
        {
            int userid = (int)HttpContext.Session.GetInt32("UserId");
            if(userid != null)
            {
                List<EmpModel> lstEmployee = new List<EmpModel>();
                lstEmployee = iuserBL.GetAllEmployees().ToList();

                return View(lstEmployee);
            }
            else
            {
                return View();
            }
            
        }
        //For Add new employee
        [HttpGet]
        /*
            Methos overloading
           [bind] bind model data with page
            ModelState.IsValid - check value are provided to all fields in model
                            Its by default came with mvc arch.
           two methods - get and post requried in mvc coz render data as well as render page
            
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

        //For edit employee data
        [HttpGet]
        //get employee data from get all 
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmpModel employee = iuserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        //match id and update data
        [HttpPost]
        public IActionResult UpdateEmployee(int id, EmpModel employee)
        {
            if (id != employee.EmpID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                iuserBL.UpdateEmployee(employee);
                return RedirectToAction("GetAllEmployees");
            }
            return View(employee);
        }

        //For details of employee by id
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmpModel employee = iuserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        //For delete employee
        /*
         [Action]- conidered post method for delete 
         */
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmpModel employee = iuserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            iuserBL.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees");
        }

        [HttpGet]
        public IActionResult Function()
        {
            return View();
        }

    }
}
