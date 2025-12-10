using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;

        public string Price { get; set; } = null!;
        public bool IsDeleted { get; set; } 
    }

    public class ProductsCategoriesDto
    {
        public int CategoryName { get; set; }

        public string Name { get; set; } = null!;
        public string Price { get; set; } = null!;
    }

    public class CreateProductDto
    {
        public string Name { get; set; } = null!;

        public string Price { get; set; } = null!;

        public int CategoryId { get; set; }
    }
    public class CategoryDto
    {
        public string Name { get; set; } = null!;
        public ICollection<ProductDto> Products { get; set; }
    }
    public class ProductEverithing
    {
        public string MainCategoryName { get; set; } = null!;
        public ICollection<CategoryDto> categories { get; set; }
        public string Name { get; set; } = null!;
        public string Price { get; set; } = null!;

    }
    public class UserOrderDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual ICollection<ProductDto> Products { get; set; } 

    }

}
