using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class CustomerTransactionFlow
{
    public int Id { get; set; }

    public Guid CustomerTransactionId { get; set; }

    public string StatusCode { get; set; } = null!;

    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime LastModifyDateTime { get; set; }

    public virtual CustomerTransaction CustomerTransaction { get; set; } = null!;
}
