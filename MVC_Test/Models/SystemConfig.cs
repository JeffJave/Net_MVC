using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class SystemConfig
{
    public string DataType { get; set; } = null!;

    public string DataCode { get; set; } = null!;

    public string DateName { get; set; } = null!;

    public bool IsActive { get; set; }

    public int Seq { get; set; }
}
