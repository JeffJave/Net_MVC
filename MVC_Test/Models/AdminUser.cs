using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class AdminUser
{
    public Guid Id { get; set; }

    public string PhoneCountryCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? AdminUserName { get; set; }

    public string? Password { get; set; }

    public string? Account { get; set; }

    public string? Remark { get; set; }

    public string StatusCode { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime LastModifyDateTime { get; set; }

    public string AdminUserNumber { get; set; } = null!;

    public Guid? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();

    public virtual ICollection<Permission> PermissionCodes { get; set; } = new List<Permission>();
}
