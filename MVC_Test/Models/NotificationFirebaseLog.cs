using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class NotificationFirebaseLog
{
    public int Id { get; set; }

    public int NotificationDetailId { get; set; }

    public string FcmdeviceId { get; set; } = null!;

    public bool Fcmstatus { get; set; }

    public string? Fcmmessage { get; set; }
}
