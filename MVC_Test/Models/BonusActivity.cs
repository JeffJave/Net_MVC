using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class BonusActivity
{
    public Guid Id { get; set; }

    public string BonusType { get; set; } = null!;

    public string? QrcodeNumber { get; set; }

    public double Bonus { get; set; }

    public string Reason { get; set; } = null!;

    public string? Remark { get; set; }

    public int TotalCount { get; set; }

    public int SendedCount { get; set; }

    public DateTime ActivityDateTime { get; set; }

    public DateTime ExpireDateTime { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime UpdateDateTime { get; set; }

    public Guid AdminUserId { get; set; }

    public string StatusCode { get; set; } = null!;

    public virtual ICollection<CustomerBonusActivity> CustomerBonusActivities { get; set; } = new List<CustomerBonusActivity>();
}
