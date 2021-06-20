using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private VoQuangNhaContext db = null;
        public ProductDao()
        {
            db = new VoQuangNhaContext();
        }
        public List<Product> ListProductAll()
        {
            return db.Products.OrderByDescending(s => s.UnitCost).ThenBy(s => s.Quantity).ToList();
        }
        public IEnumerable<Product> ListProductWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.OrderByDescending(s => s.UnitCost).ThenBy(s => s.Quantity).Where(x => x.Name.Contains(keysearch)||x.Category.Name.Contains(keysearch));
            }

            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
        public List<Product> ListNewProduct(int top)

        {
            return db.Products.OrderByDescending(x=>x.ID).Take(top).ToList();
        }
        // dùng để tạo slide
        public List<Product> ListProductIphone(int top)
        {
            return db.Products.Where(x => x.CategoryID == 1).OrderByDescending(x => x.ID).Take(top).ToList();
        }
        
        public List<Product> ListProductSamsung(int top)
        {
            return db.Products.Where(x => x.CategoryID == 2).OrderByDescending(x => x.ID).Take(top).ToList();
        }
        public List<Product> ListProductNokia(int top)
        {
            return db.Products.Where(x => x.CategoryID == 3).OrderByDescending(x => x.ID).Take(top).ToList();
        }
        public List<Product> ListProductVivo(int top)
        {
            return db.Products.Where(x => x.CategoryID == 4).OrderByDescending(x => x.ID).Take(top).ToList();
        }
        public List<Product> ListProductOppo(int top)
        {
            return db.Products.Where(x => x.CategoryID == 5).OrderByDescending(x => x.ID).Take(top).ToList();
        }
        
        // hiển thị chi tiết client
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        //lấy tất cả sản phẩm bởi cái mã danh mục
        public List<Product> ListByCategoryID(long id)
        {
            return db.Products.Where(x => x.CategoryID == id).ToList();
        }
        
    }
}
