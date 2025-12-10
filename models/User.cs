using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public int AdressId { get; set; }

    public virtual Adress Adress { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
