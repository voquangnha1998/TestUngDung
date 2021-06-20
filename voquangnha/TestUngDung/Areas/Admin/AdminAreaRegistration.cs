using System.Web.Mvc;

namespace TestUngDung.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            //thử
            context.MapRoute(
               name: "CreateCategoryProduct",
               url: "them-loai-san-pham",
               defaults: new { controller = "Categories", action = "Create", id = UrlParameter.Optional },
               namespaces: new[] { "TestUngDung.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               name: "AllCategoryProduct",
               url: "danh-sach-loai-san-pham",
               defaults: new { controller = "Categories", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "TestUngDung.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               name: "CreateProduct",
               url: "them-san-pham",
               defaults: new { controller = "Products", action = "Create", id = UrlParameter.Optional },
               namespaces: new[] { "TestUngDung.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               name: "AllProduct",
               url: "danh-sach-san-pham",
               defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "TestUngDung.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               name: "AllUserName",
               url: "danh-sach-tai-khoan",
               defaults: new { controller = "UserAccounts", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "TestUngDung.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               name: "CreateUserName",
               url: "tao-tai-khoan",
               defaults: new { controller = "UserAccounts", action = "Create", id = UrlParameter.Optional },
               namespaces: new[] { "TestUngDung.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               name: "Home page",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "TestUngDung.Areas.Admin.Controllers" }
           );
            

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}