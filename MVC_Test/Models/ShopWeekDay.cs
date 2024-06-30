using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class ShopWeekDay
{
    public int Id { get; set; }

    public string WeekDay { get; set; } = null!;

    public Guid ShopId { get; set; }

    public virtual Shop Shop { get; set; } = null!;

    public virtual ICollection<ShopWeekDayTime> ShopWeekDayTimes { get; set; } = new List<ShopWeekDayTime>();
}
