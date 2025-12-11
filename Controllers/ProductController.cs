using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
      

        private readonly ProductService _productService = new();

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            Product p = _productService.AddProduct(product);
            return Ok(p);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct() {
            var products = await _productService.GetAllProduct();
            return Ok(products);
        
        }



        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProducts(List<Product> products)
        {
            List<Product> p = _productService.AddProduct(products);
            return Ok(p);
        }

        [HttpPost]
        [Route("GetProductByCategory/{categoryId}")]
        public IActionResult GetProductByCategory(int categoryId)
        {
            return Ok(_productService.GetProductByCategory(categoryId));
        }
        [HttpGet]
        [Route("GetProductSort")]
        public IActionResult GetProductSort()
        {
            return Ok(_productService.GetProductSort());
        }

        [HttpGet]
        [Route("GetProductsWhithCategoies")]
        public IActionResult GetProductsWhithCategoies()
        {
            return Ok(_productService.GetProductsWhithCategoies());
        }

        [HttpGet]
        [Route("GetOrderByUser/{userId}")]

        public IActionResult GetOrderByUser(int userId)
        {
            return Ok(_productService.GetOrderByUser(userId));
        }
        

        [HttpPut]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            return Ok(_productService.DeleteProduct(productId));
        }

        [HttpGet]
        [Route("GetEverything")]
        public IActionResult GetEverything()
        {
            return Ok(_productService.GetEverything());
        }
        [HttpPost]
        [Route("createProductWithPro")]
        public IActionResult CreateProductWithPro(CreateProductDto product) 
        { 
            return Ok(_productService.CreateProductWithPro(product));
        }




       
    }
}
