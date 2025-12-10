using WebApplication1.Models;

namespace WebApplication1.models
{
    public class MainCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
