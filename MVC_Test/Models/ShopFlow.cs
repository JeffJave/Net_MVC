using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class ShopFlow
{
    public Guid ShopId { get; set; }

    public int Id { get; set; }

    public string StatusCode { get; set; } = null!;

    public DateTime LastModifyDateTime { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
