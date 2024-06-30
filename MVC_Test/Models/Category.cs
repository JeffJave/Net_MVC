using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class Category
{
    public string CategoryCode { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string StatusCode { get; set; } = null!;

    public int Seq { get; set; }

    public string CategoryPath { get; set; } = null!;

    public string? CouponImagePath { get; set; }

    public virtual ICollection<ShopCategoryMapping> ShopCategoryMappings { get; set; } = new List<ShopCategoryMapping>();
}
