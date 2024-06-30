using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class SystemAnnounce
{
    public int Id { get; set; }

    public string AnnounceContent { get; set; } = null!;

    public string? ImagePath { get; set; }

    public DateTime AnnounceDateTime { get; set; }

    public DateTime ExpireDateTime { get; set; }

    public string StatusCode { get; set; } = null!;

    public string AnnounceTitle { get; set; } = null!;

    public string? AnnounceLink { get; set; }

    public string? Remark { get; set; }

    public string? AnnounceTypeCode { get; set; }

    public bool? IsHomePageDisplay { get; set; }

    public DateTime CreateDateTime { get; set; }

    public bool IsPushNotification { get; set; }

    public virtual ICollection<SystemAnnounceMapping> SystemAnnounceMappings { get; set; } = new List<SystemAnnounceMapping>();
}
