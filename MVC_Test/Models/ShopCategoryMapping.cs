using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class ShopCategoryMapping
{
    public Guid ShopId { get; set; }

    public string CategoryCode { get; set; } = null!;

    public bool IsMaster { get; set; }

    public virtual Category CategoryCodeNavigation { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
