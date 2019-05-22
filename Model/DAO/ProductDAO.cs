using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDAO
    {
        ShopDbContext db = null;
        public ProductDAO()
        {
            db = new ShopDbContext();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Product.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Product.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
    }
}
