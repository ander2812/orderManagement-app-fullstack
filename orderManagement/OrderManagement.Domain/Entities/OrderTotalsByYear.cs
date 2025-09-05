using System;
using System.Collections.Generic;

namespace OrderManagement.Domain.Entities;

public partial class OrderTotalsByYear
{
    public int? orderyear { get; set; }

    public int? qty { get; set; }
}
