using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public string? CompanyName { get; set; }

    public string? ImagePath { get; set; }

    public string? Slogan { get; set; }

    public string? StatusCode { get; set; }

    public virtual ICollection<AdminUser> AdminUsers { get; set; } = new List<AdminUser>();
}
