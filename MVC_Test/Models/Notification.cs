using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string NotificationName { get; set; } = null!;

    public string NotificationFrom { get; set; } = null!;

    public string NotificationTo { get; set; } = null!;

    public int NotificationCount { get; set; }

    public string NotificationType { get; set; } = null!;

    public DateTime NotificationDateTime { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? TargrtUrl { get; set; }

    public string CreateUser { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public string UpdateUser { get; set; } = null!;

    public DateTime UpdateDateTime { get; set; }

    public int MaxRetryCount { get; set; }

    public string StatusCode { get; set; } = null!;

    public virtual ICollection<NotificationDetail> NotificationDetails { get; set; } = new List<NotificationDetail>();
}
