using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class BuildingInformation
{
    public int Id { get; set; }

    public string BuildingName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string UrlLink { get; set; } = null!;

    public string StatusCode { get; set; } = null!;
}
