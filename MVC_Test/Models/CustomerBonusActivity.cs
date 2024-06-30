using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class CustomerBonusActivity
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid BonusActivityId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public double Bonus { get; set; }

    public virtual BonusActivity BonusActivity { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
