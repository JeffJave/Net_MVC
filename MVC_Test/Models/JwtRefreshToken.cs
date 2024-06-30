using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class JwtRefreshToken
{
    public string Token { get; set; } = null!;

    public DateTime LastModifyDateTime { get; set; }
}
