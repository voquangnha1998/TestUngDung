using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserAccountsController : BaseController
    {
        private VoQuangNhaContext db = new VoQuangNhaContext();

        // GET: Admin/UserAccounts
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListAll();

            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)

        {

            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            if (searchString == "")
            {
                return RedirectToAction("Index");
            }
            return View(model.ToPagedList(page, pagesize));
        }
        // GET: Admin/UserAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: Admin/UserAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAccount u)
        {
            var username = new UserDao();
            var model = username.CheckUsername(u.UserName);
            try
            {
               
                if (model == 0)
                {
                    var pass = Encryptor.EncryptMD5(u.Password);
                    u.Password = pass;
                    db.UserAccounts.Add(u);
                    db.SaveChanges();
                    SetAlert("Tạo tài khoản thành công", "success");
                    //ViewBag.msg = "Tạo người dùng thành công !!!!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Tạo tài khoản không thành công, trùng 'Tên tài khoản'", "warning");
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
            
        }

        // GET: Admin/UserAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(db.UserAccounts.Where(u => u.ID == id).FirstOrDefault());
        }

        // POST: Admin/UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserAccount u)
        {
            var pass = Encryptor.EncryptMD5(u.Password);
            u.Password = pass;
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();
            SetAlert("Cập nhật dùng thành công", "success");
            //ViewBag.msg = "Cập nhật người dùng thành công !!!!!";
            return RedirectToAction("Index");
        }

        // GET: Admin/UserAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            //ViewBag.msg = "Xóa người dùng thành công !!!!!";
            return View(db.UserAccounts.Where(u => u.ID == id&&u.Status==false).FirstOrDefault());
        }

        // POST: Admin/UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, UserAccount user)
        {
            try
            {
                user = db.UserAccounts.Where(u => u.ID == id && u.Status == false).FirstOrDefault();
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                SetAlert("Xóa người dùng thành công", "success");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}
