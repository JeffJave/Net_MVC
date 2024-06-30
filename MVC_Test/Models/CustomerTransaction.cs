using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class CustomerTransaction
{
    public Guid Id { get; set; }

    public Guid ShopId { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime TransactionDateTime { get; set; }

    public double? TotalAmount { get; set; }

    public double? DiscountTotalAmount { get; set; }

    public double? CustomerRating { get; set; }

    public string? CustomerComment { get; set; }

    public double TotalBonus { get; set; }

    public string? CancelReason { get; set; }

    public string StatusCode { get; set; } = null!;

    public string? RejectCancelReason { get; set; }

    public DateTime? CustomerCommentDateTime { get; set; }

    public DateTime LastUpdateDateTime { get; set; }

    public string? AdminUserModifyReason { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<CustomerTransactionBonusRecord> CustomerTransactionBonusRecords { get; set; } = new List<CustomerTransactionBonusRecord>();

    public virtual ICollection<CustomerTransactionDiscount> CustomerTransactionDiscounts { get; set; } = new List<CustomerTransactionDiscount>();

    public virtual ICollection<CustomerTransactionFlow> CustomerTransactionFlows { get; set; } = new List<CustomerTransactionFlow>();

    public virtual Shop Shop { get; set; } = null!;
}
