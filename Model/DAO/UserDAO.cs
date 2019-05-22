using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;

namespace Model.DAO
{
    public class UserDAO
    {
        ShopDbContext db = null;

        public UserDAO()
        {
            db = new ShopDbContext();
        }

        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.Name = entity.Name;
                if(!string.IsNullOrEmpty(entity.PassWord))
                {
                    user.PassWord = entity.PassWord;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifledBy = entity.ModifledBy;
                user.ModifledDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.User;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName );
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.PassWord == passWord)
                        return 1;
                    else
                        return -2;
                    
                }
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
            
        }

        public bool ChangeStatus(long id)
        {
            var user = db.User.Find(id);
            
            user.Status = !user.Status;
            db.SaveChanges();

            return user.Status;
        }


    }
}
