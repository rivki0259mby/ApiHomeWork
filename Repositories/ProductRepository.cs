using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductRepository
    {

        StoreContext context = StoreContextFactory.CreateContext();

        public Product AddProduct (Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

            return product;
        }

        public async Task<List<Product>>GetAllProduct()
        {
           var products = await context.Products
                .ToListAsync();
            return products;
        }
    


        public List<Product> AddProducts(List<Product> products)
        {
            context.Products.AddRange(products);
            context.SaveChanges();

            return products;
        }
        //public List<ProductDto> GetProductByCategory(int categoryId)
        //{
        //    return context.Products
        //        .Where(pc => pc.CategoryId == categoryId && pc.IsDeleted == false)
        //        .Select(p => new ProductDto
        //        {
                    
        //            Name = p.Name,
        //            Price = p.Price
        //        }).ToList();
            
        //}

        public List<ProductDto> GetProductSort()
        {
           return  context.Products
                .OrderBy(pc => pc.CategoryId)
                .Where(pc => pc.IsDeleted == false)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

           
        }

        public List<CategoryDto> GetProductsWhithCategoies()
        {
            return context.Categories
                .Select(c => new CategoryDto
                {
                    
                   Name =  c.Name,
                   Products = c.Products
                    .Select(p => new ProductDto
                    {
                       Name =  p.Name , 
                       Price = p.Price
                    }).ToList()
                   
                }).ToList();
            
        }

        public List<UserOrderDto> GetOrderByUser(int userId)
        {
               return context.Users
                .Where(us => us.Id == userId)
                .Select(u => new UserOrderDto
                {
                   Id =  u.Id,
                   FirstName= u.FirstName,
                   LastName =  u.LastName,
                    Products = u.Products
                    .Where(p => p.IsDeleted == false)
                    .Select(p => new ProductDto
                    {
                       
                        Name = p.Name,
                       Price =  p.Price
                    }).ToList()
                }).ToList();   
            
        }

        public Product DeleteProduct(int productId)
        {
            var product = context.Products.FirstOrDefault
                (p => p.Id == productId);
            product.IsDeleted = true;
            context.SaveChanges();

            return product;
        }

        public List<ProductEverithing> GetEverything()
        {
            return context.MainCategories
                  .Select(mc => new ProductEverithing
                  {
                      MainCategoryName = mc.Name,
                      categories = mc.Categories
                      .Select(c => new CategoryDto
                      {
                          Name = c.Name,
                          Products = c.Products
                          .Where(p =>p.IsDeleted == false)  
                          .Select(p => new ProductDto
                          {
                              Name = p.Name,
                              Price = p.Price,
                          }).ToList()
                      }).ToList()
                  }).ToList();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return context.Products
                .FromSqlInterpolated($"EXEC GetProductsByCategory @categoryId={categoryId}")
                .ToList();
        }

        public int CreateProductWithPro(CreateProductDto product)
        {
            var outputParam = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var parameters = new[]
            {
            new SqlParameter("@name", product.Name),
            new SqlParameter("@price", product.Price),
            new SqlParameter("@categoryId", product.CategoryId),
            
            outputParam
         };


            context.Database.ExecuteSqlRaw(
            "EXEC AddProductPro @name, @price,@categoryId, @Id OUTPUT",
            parameters);

            // Get the output value
            int Id = (int)outputParam.Value;


            return Id;
        }

        public int CreateProductWithTra(CreateProductDto product)
        {
            var outputParam = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var parameters = new[]
            {
            new SqlParameter("@name", product.Name),
            new SqlParameter("@price", product.Price),
            new SqlParameter("@categoryId", product.CategoryId),

            outputParam
         };


            context.Database.ExecuteSqlRaw(
            "EXEC AddProductPro @name, @price,@categoryId, @Id OUTPUT",
            parameters);

            // Get the output value
            int Id = (int)outputParam.Value;


            return Id;
        }



    }
}
