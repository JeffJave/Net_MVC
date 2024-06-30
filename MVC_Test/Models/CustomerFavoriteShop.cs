using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class CustomerFavoriteShop
{
    public int Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid ShopId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
