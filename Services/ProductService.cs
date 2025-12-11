using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ProductService
    {
        private readonly ProductRepository repository = new();

        public Product AddProduct(Product product)
        {
            return repository.AddProduct(product);
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return repository.GetProductByCategory(categoryId);
        }

        public List<ProductDto> GetProductSort()
        {
            return repository.GetProductSort();
        }

        public List<CategoryDto> GetProductsWhithCategoies()
        {
            return repository.GetProductsWhithCategoies();
        }

        public List<UserOrderDto> GetOrderByUser(int userId)
        {
            return repository.GetOrderByUser(userId);
        }

        public Product DeleteProduct(int productId)
        {
            return repository.DeleteProduct(productId);
        }

        public async Task<List<ProductDto>> GetAllProduct() 
        {
            var a = await repository.GetAllProduct();
            return a.Select(p => new ProductDto
            {
                Name=p.Name,
                Price=p.Price,
                IsDeleted=p.IsDeleted,

            }).ToList();

        }

        public List<ProductEverithing> GetEverything()
        {
            return repository.GetEverything();
        }

        internal List<Product> AddProduct(List<Product> products)
        {
            throw new NotImplementedException();
        }

        public int CreateProductWithPro(CreateProductDto product)
        {
            return repository.CreateProductWithPro(product);
                }
    }
}
