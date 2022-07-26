using CRUD_Using_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Using_EF.Data
{
   
    public class ProductDAL
    {
        ApplicationDbContext db;
        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
       

        public IQueryable<Product>GetAllProducts()
        {
            // return db.Products.ToList();
            var result = from p in db.Products
                         select p;
            return result;

        }
        public Product GetProductById(int id)
        {
            Product p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return p;

        }
        public int AddProduct(Product prod)
        {
            db.Products.Add(prod);
            int result = db.SaveChanges();
            return result;

        }
        public int UpdateProduct(Product prod)
        {
            int result = 0;
            Product p=db.Products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if(p !=null)
            {
                p.Name = prod.Name;
                p.Price = prod.Price;
                result = db.SaveChanges();
            }
            return result;

        }

        public int DeleteProduct(Product prod)
        {
            int result = 0;
            Product p = db.Products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (p != null)
            {

                db.Products.Remove(p);
                result = db.SaveChanges();
            }
            return result;


        }


    }
}
