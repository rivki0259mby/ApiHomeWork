using System;
using System.Collections.Generic;
using WebApplication1.models;

namespace WebApplication1.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MainCategoryInd { get; set; }

    public MainCategory MainCategory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
