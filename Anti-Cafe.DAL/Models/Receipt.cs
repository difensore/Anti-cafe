using System;
using System.Collections.Generic;

namespace Anti_Cafe;

public partial class Receipt
{
    public string Id { get; set; } = null!;

    public string Admin { get; set; } = null!;

    public int Person { get; set; }

    public decimal Value { get; set; }

    public DateTime TimeIn { get; set; }

    public DateTime TimeOut { get; set; }
}
