using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class SystemAdMapping
{
    public int SystemAdId { get; set; }

    public string SystemAdTypeCode { get; set; } = null!;

    public virtual SystemAd SystemAd { get; set; } = null!;
}
