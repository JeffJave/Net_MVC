using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class CustomerTransactionBonusRecord
{
    public Guid Id { get; set; }

    public double BonusPoint { get; set; }

    public string BonusTypeCode { get; set; } = null!;

    public DateTime BonusDateTime { get; set; }

    public Guid? CustomerTransactionId { get; set; }

    public string RecipientTypeCode { get; set; } = null!;

    public Guid? RecipientId { get; set; }

    public virtual CustomerTransaction? CustomerTransaction { get; set; }
}
