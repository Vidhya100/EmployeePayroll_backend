using BusinessLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service;

namespace EmployeePayrolMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBL iuserBL;
        //for sessons
        private readonly IHttpContextAccessor context;

        public UserController(IUserBL iuserBL, IHttpContextAccessor context)
        {
            this.iuserBL = iuserBL;
            this.context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([Bind]UserModel userModel)
        {
            //EmpController empController;
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Email",userModel.Email);
                HttpContext.Session.SetString("Password", userModel.Password);
                HttpContext.Session.SetInt32("UserId",userModel.UserId);
                iuserBL.Login(userModel);
                return RedirectToAction("GetAllEmployees", "Emp"); 
            }
            return View(userModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register([Bind]UserModel userModel)
        {
            if(ModelState.IsValid)
            {
                iuserBL.UserRegi(userModel);
                return RedirectToAction("Login");
            }
            return View(userModel);
        }
    }
}
