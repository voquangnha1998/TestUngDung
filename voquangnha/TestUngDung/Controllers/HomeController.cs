using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var producdao = new ProductDao();
            var categoryproductdao = new CategoryDao();
            ViewBag.NewProducts = producdao.ListNewProduct(2);
            //danhmuc
            ViewBag.CategoryProduct = categoryproductdao.ListCategoryProduct();
            ViewBag.CategoryProduct5 = categoryproductdao.ListCategoryProduct(5);
            // slide
            ViewBag.IphoneProducts = producdao.ListProductIphone(3);
            ViewBag.SamsungProducts = producdao.ListProductSamsung(3);
            ViewBag.NokiaProducts = producdao.ListProductNokia(3);
            ViewBag.VivoProducts = producdao.ListProductVivo(3);
            ViewBag.OppoProducts = producdao.ListProductOppo(3);
            
            //

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}