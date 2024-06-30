using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public string PhoneCountryCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string CustomerNumber { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? GenderCode { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string StatusCode { get; set; } = null!;

    public string? AvatarPath { get; set; }

    public Guid? RecommendCustomerId { get; set; }

    public bool? IsGpsEnabled { get; set; }

    public bool? IsNotificationEnabled { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime LastModifyDateTime { get; set; }

    public virtual ICollection<CustomerBonusActivity> CustomerBonusActivities { get; set; } = new List<CustomerBonusActivity>();

    public virtual ICollection<CustomerFavoriteShop> CustomerFavoriteShops { get; set; } = new List<CustomerFavoriteShop>();

    public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; } = new List<CustomerTransaction>();

    public virtual ICollection<ShopDiscountCoupon> ShopDiscountCoupons { get; set; } = new List<ShopDiscountCoupon>();

    public virtual ICollection<Permission> PermissionCodes { get; set; } = new List<Permission>();
}
