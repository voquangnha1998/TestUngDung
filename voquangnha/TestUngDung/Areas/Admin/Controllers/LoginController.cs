using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Model;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        VoQuangNhaContext db = new VoQuangNhaContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel admin)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(admin.UserName, Encryptor.EncryptMD5(admin.Password));
                if (result == 1)
                {
                    Session.Add(Constants.USER_SESSION, admin);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }        
            }
            return View("Index");
        }
    }
}