using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class NotificationDetail
{
    public int Id { get; set; }

    public int NotificationId { get; set; }

    public string RecipientId { get; set; } = null!;

    public string RecipientName { get; set; } = null!;

    public DateTime LastExecTime { get; set; }

    public int? RetryCount { get; set; }

    public string? ReadUser { get; set; }

    public DateTime? ReadDateTime { get; set; }

    public string StatusCode { get; set; } = null!;

    public string? ClickAction { get; set; }

    public string? OpenTarget { get; set; }

    public string? ErrorMessage { get; set; }

    public virtual Notification Notification { get; set; } = null!;
}
