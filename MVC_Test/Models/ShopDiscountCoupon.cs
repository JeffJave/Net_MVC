using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class ShopDiscountCoupon
{
    public string SerialNumber { get; set; } = null!;

    public Guid ShopId { get; set; }

    public double Amount { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime? ExchangeDateTime { get; set; }

    public DateTime? ExpireDateTime { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UseDateTime { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<CustomerTransactionDiscount> CustomerTransactionDiscounts { get; set; } = new List<CustomerTransactionDiscount>();

    public virtual Shop Shop { get; set; } = null!;
}
