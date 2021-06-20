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

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoriesController : BaseController
    {
        private VoQuangNhaContext db = new VoQuangNhaContext();

        // GET: Admin/Categories
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new CategoryDao();
            var model = user.ListAll();

            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)

        {

            var cate = new CategoryDao();
            var model = cate.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            if (searchString == "")
            {
                return RedirectToAction("Index");
            }
            return View(model.ToPagedList(page, pagesize));
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            var name = new CategoryDao();
            var model = name.CheckName(category.Name);
            try
            {

                if (model == 0)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    SetAlert("Tạo loại sản phẩm thành công", "success");
                    //ViewBag.msg = "Tạo người dùng thành công !!!!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Tạo loại sản phẩm không thành công, trùng 'Tên loại SP'", "warning");
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(db.Categories.Where(u => u.ID == id).FirstOrDefault());
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            SetAlert("Cập nhật loại sản phẩm thành công", "success");
           
            return RedirectToAction("Index");
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.msg = "Xóa người dùng thành công !!!!!";
            return View(db.Categories.Where(u => u.ID == id).FirstOrDefault());
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Category cate)
        {
            try
            {
                cate = db.Categories.Where(u => u.ID == id).FirstOrDefault();
                db.Categories.Remove(cate);
                db.SaveChanges();
                SetAlert("Xóa người loại sản phẩm thành công", "success");
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
