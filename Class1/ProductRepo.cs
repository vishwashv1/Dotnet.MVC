using ASPWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class1
{
    public interface IProductDB
    {
        void AddProduct(Product1 product);
        void UpdateProduct(Product1 product);
        void DeleteProduct(int id);
        List<Product1> GetAllProducts();
    }

    public static class ProductFac
    {
        public static IProductDB GetComponent() => new ProductDB();
    }
    class ProductDB : IProductDB
    {
        static ProductEntities context = new ProductEntities();
        public void AddProduct(Product1 Product)
        {
         
            
            context.Product1.Add(Product);
            context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var found = context.Product1.First((p) => p.ProductId == id);
            context.Product1.Remove(found);
            context.SaveChanges();
        }

        public List<Product1> GetAllProducts() => context.Product1.ToList();

        public void UpdateProduct(Product1 product)
        {
            var found = context.Product1.First((p) => p.ProductId == product.ProductId);
            found.ProductImage = product.ProductImage;
            found.ProductName = product.ProductName;
            found.Price = product.Price;
            found.Quantity = product.Quantity;
            context.SaveChanges();
        }
    }

}
