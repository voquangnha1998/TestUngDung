using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private VoQuangNhaContext db = new VoQuangNhaContext();

        // GET: Admin/Products
        public ActionResult Index(int page = 1, int pagesize = 5)
        {

            var products = new ProductDao();
            var model = products.ListProductAll();
            return View(model.ToPagedList(page, pagesize));

            /*var products = db.Products.Include(p => p.CategotyProduct);
            return View(products.ToList());*/
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)

        {

            var pro = new ProductDao();
            var model = pro.ListProductWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            if (searchString == "")
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            Product p = new Product();
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", p.CategoryID);
            return View(p);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, HttpPostedFileBase Imgfile)
        {
            Product product = new Product();

            string path = Uploadimage(Imgfile);
            
            if (path.Equals("-1"))
            {
               
            }
            else
            {
                product.Name = p.Name;
                product.UnitCost = p.UnitCost;
                product.Image = path;
                product.Quantity = p.Quantity;
                product.Description = p.Description;
                product.Status = p.Status;
                product.CategoryID = p.CategoryID;
                db.Products.Add(product);

                db.SaveChanges();
                SetAlert("Tạo sản phẩm thành công", "success");
                ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
                //insert xong về trang index.
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            //mới thêm vào
            //ModelState.Clear();
            return View();
            /*Product product = new Product();

            string path = Uploadimage(Imgfile);

            if (path.Equals("-1"))
            {
                SetAlert("Chưa chọn ảnh", "error");
            }
            else
            {
                //Name, UnitCost, Quantity, Image, Description, Status
                product.Name = p.Name;
                product.UnitCost = p.UnitCost;
                product.Image = path;
                product.Quantity = p.Quantity;
                product.Description = p.Description;
                product.Status = p.Status;
                
                db.Products.Add(product);

                db.SaveChanges();
                
                ViewBag.CatProID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);               
                SetAlert("Tạo sản phẩm thành công", "success");
                return RedirectToAction("Index");
            }
            ViewBag.CatProID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);

            return View();*/
        }
        public string Uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);
                        
                        //    ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }
            return path;

        }
        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Product p)
        {
            try
            {
                Random r = new Random();
                int random = r.Next();
                if (p.Imgfile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(p.Imgfile.FileName);
                    string ex = Path.GetExtension(p.Imgfile.FileName);
                    filename = filename + ex;
                    p.Image = "~/Content/upload/" + random + filename;
                    p.Imgfile.SaveAs(Path.Combine(Server.MapPath("~/Content/upload/"), random + filename));

                }

                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Cập nhật dùng thành công", "success");
                ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", p.CategoryID);
                
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }

            
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(db.Products.Where(u => u.ID == id).FirstOrDefault());
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            SetAlert("Xóa sản phẩm thành công", "success");
            return RedirectToAction("Index");
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
