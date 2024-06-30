using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class ShopWeekDayTime
{
    public int ShopWeekDayId { get; set; }

    public TimeSpan TimeFrom { get; set; }

    public TimeSpan TimeTo { get; set; }

    public string TimePeriodCode { get; set; } = null!;

    public int Id { get; set; }

    public bool? IsChecked { get; set; }

    public virtual ShopWeekDay ShopWeekDay { get; set; } = null!;
}
