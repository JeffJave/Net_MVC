using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class VerificationCode
{
    public string VerifyCode { get; set; } = null!;

    public string Recipient { get; set; } = null!;

    public DateTime ExpireDateTime { get; set; }

    public string VerificationTypeCode { get; set; } = null!;
}
