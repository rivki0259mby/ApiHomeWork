using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }
}
