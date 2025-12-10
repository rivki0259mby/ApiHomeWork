using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Adress
{
    public int Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
