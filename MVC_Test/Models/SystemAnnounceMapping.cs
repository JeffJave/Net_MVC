using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class SystemAnnounceMapping
{
    public int SystemAnnounceId { get; set; }

    public string AnnounceTypeCode { get; set; } = null!;

    public bool IsHomePageDisplay { get; set; }

    public virtual SystemAnnounce SystemAnnounce { get; set; } = null!;
}
