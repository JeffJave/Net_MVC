using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class SystemAd
{
    public int Id { get; set; }

    public string ImagePath { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? UrlLink { get; set; }

    public string SystemAdTypeCode { get; set; } = null!;

    public string AdTypeCode { get; set; } = null!;

    public int Seq { get; set; }

    public string StatusCode { get; set; } = null!;

    public string? Remark { get; set; }

    public DateTime CreateDateTime { get; set; }

    public bool IsPushNotification { get; set; }

    public string? ImagePathForList { get; set; }

    public virtual ICollection<SystemAdMapping> SystemAdMappings { get; set; } = new List<SystemAdMapping>();
}
