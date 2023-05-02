using System;
using System.Collections.Generic;

namespace Anti_Cafe;

public partial class Reservation
{
    public string Id { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public string Table { get; set; } = null!;

    public DateTime TimeIn { get; set; }

    public DateTime? TimeOut { get; set; }

    public int Persons { get; set; }

    public string Name { get; set; } = null!;

    public virtual Table TableNavigation { get; set; } = null!;
}
