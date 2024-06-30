using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class Shop
{
    public Guid Id { get; set; }

    public string ShopName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string TaxId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string TelAreaCode { get; set; } = null!;

    public string TelNumber { get; set; } = null!;

    public string HomeImagePath { get; set; } = null!;

    public string? PhoneCountryCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Introduction { get; set; }

    public string? Remark { get; set; }

    public string? LineUrl { get; set; }

    public string? FaceBookUrl { get; set; }

    public string? InstagramUrl { get; set; }

    public string? OfficialWebUrl { get; set; }

    public double DiscountRate { get; set; }

    public bool IsFacebookEnabled { get; set; }

    public bool IsInstagramEnabled { get; set; }

    public bool IsOfficialWebEnabled { get; set; }

    public int CouponValidDays { get; set; }

    public string StatusCode { get; set; } = null!;

    public DateTime LastModifyDateTime { get; set; }

    public bool IsLineEnabled { get; set; }

    public string OwnerName { get; set; } = null!;

    public string OwnerPhoneNumber { get; set; } = null!;

    public string OwnerIdNumber { get; set; } = null!;

    public string ShopNumber { get; set; } = null!;

    public bool IsFirstLogin { get; set; }

    public string? AdminUserRemark { get; set; }

    public string OwnerGenderCode { get; set; } = null!;

    public Guid? AdminUserId { get; set; }

    public virtual AdminUser? AdminUser { get; set; }

    public virtual ICollection<CustomerFavoriteShop> CustomerFavoriteShops { get; set; } = new List<CustomerFavoriteShop>();

    public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; } = new List<CustomerTransaction>();

    public virtual ICollection<ShopAd> ShopAds { get; set; } = new List<ShopAd>();

    public virtual ICollection<ShopCategoryMapping> ShopCategoryMappings { get; set; } = new List<ShopCategoryMapping>();

    public virtual ICollection<ShopDiscountCoupon> ShopDiscountCoupons { get; set; } = new List<ShopDiscountCoupon>();

    public virtual ICollection<ShopEmployee> ShopEmployees { get; set; } = new List<ShopEmployee>();

    public virtual ICollection<ShopFlow> ShopFlows { get; set; } = new List<ShopFlow>();

    public virtual ICollection<ShopWeekDay> ShopWeekDays { get; set; } = new List<ShopWeekDay>();

    public virtual ICollection<ShopEmployee> ShopEmployeesNavigation { get; set; } = new List<ShopEmployee>();
}
