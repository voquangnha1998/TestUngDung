using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
   public class CategoryDao
    {
        private VoQuangNhaContext db = null;
        public CategoryDao()
        {
            db = new VoQuangNhaContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Category> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }

            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
        public int CheckName(string name)
        {
            var result = db.Categories.SingleOrDefault(x => x.Name.Contains(name));

            //var result = db.Admins.Where(s => s.UserName.Equals(user) && s.Pass.Equals(pass)).ToList();
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<Category> ListCategoryProduct()
        {
            return db.Categories.ToList();
        }
        public List<Category> ListCategoryProduct(int top)
        {
            return db.Categories.OrderBy(x => x.ID).Take(top).ToList();
        }
        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }
        
    }
}
