using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class ShopEmployee
{
    public Guid Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string? PhoneCountryCode { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string StatusCode { get; set; } = null!;

    public string? IdNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime LastModifyDateTime { get; set; }

    public Guid? ShopId { get; set; }

    public string? Title { get; set; }

    public virtual Shop? Shop { get; set; }

    public virtual ICollection<Permission> PermissionCodes { get; set; } = new List<Permission>();

    public virtual ICollection<Role> RoleCodes { get; set; } = new List<Role>();

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
