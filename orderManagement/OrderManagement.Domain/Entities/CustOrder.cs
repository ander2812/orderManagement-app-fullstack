using System;
using System.Collections.Generic;

namespace OrderManagement.Domain.Entities;

public partial class CustOrder
{
    public int? custid { get; set; }

    public DateTime? ordermonth { get; set; }

    public int? qty { get; set; }
}
