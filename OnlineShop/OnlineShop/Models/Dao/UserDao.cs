using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Models;

namespace OnlineShop.Models.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();

        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }

        public bool Login(string userName,string passWord)
        {
           var  result = db.Users.Count(x => x.Username == userName && x.Password == passWord);
            if(result > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        


    }
}
