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
    }
}
