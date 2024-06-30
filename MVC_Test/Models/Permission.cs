using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class Permission
{
    public string PermissionCode { get; set; } = null!;

    public string PermissionName { get; set; } = null!;

    public int Seq { get; set; }

    public string StatusCode { get; set; } = null!;

    public string Module { get; set; } = null!;

    public virtual ICollection<AdminUser> AdminUsers { get; set; } = new List<AdminUser>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Role> RoleCodes { get; set; } = new List<Role>();

    public virtual ICollection<ShopEmployee> ShopEmployees { get; set; } = new List<ShopEmployee>();
}
