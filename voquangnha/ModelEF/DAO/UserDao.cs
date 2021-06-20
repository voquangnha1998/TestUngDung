using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private VoQuangNhaContext db = null;
        public UserDao()
        {
            db = new VoQuangNhaContext();
        }
        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));

            //var result = db.UserAccounts.Where(s => s.UserName.Equals(user) && s.Password.Equals(pass)).ToList();
            if (result == null)
            {
                return 0;
            }
            else
            {

                return 1;
            }
        }
        public string Insert(UserAccount entityuser)
        {
            db.UserAccounts.Add(entityuser);
            db.SaveChanges();
            return entityuser.UserName;
        }
        public int CheckUsername(string username)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(username));

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
        public UserAccount Find(string username)
        {
            return db.UserAccounts.Find(username);
        }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }
        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }

            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
    }
}
