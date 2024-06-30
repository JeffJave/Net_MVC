using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class ShopAd
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public Guid ShopId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? UrlLink { get; set; }

    public int Seq { get; set; }

    public string StatusCode { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
