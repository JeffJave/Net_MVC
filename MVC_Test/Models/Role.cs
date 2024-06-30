using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class Role
{
    public string RoleCode { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public int Seq { get; set; }

    public string StatusCode { get; set; } = null!;

    public virtual ICollection<Permission> PermissionCodes { get; set; } = new List<Permission>();

    public virtual ICollection<ShopEmployee> ShopEmployees { get; set; } = new List<ShopEmployee>();
}
