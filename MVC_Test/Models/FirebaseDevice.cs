using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class FirebaseDevice
{
    public string Owner { get; set; } = null!;

    public string DeviceId { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }
}
