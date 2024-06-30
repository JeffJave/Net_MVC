using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class SystemLog
{
    public int Id { get; set; }

    public string Application { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string Level { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public string? RequestParams { get; set; }

    public string? RequestBody { get; set; }

    public string RequestIp { get; set; } = null!;

    public string? LogUser { get; set; }
}
