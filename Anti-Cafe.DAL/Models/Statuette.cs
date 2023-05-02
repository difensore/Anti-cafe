using System;
using System.Collections.Generic;

namespace Anti_Cafe;

public partial class Statuette
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Persons { get; set; }

    public DateTime TimeIn { get; set; }

    public DateTime TimeOut { get; set; }

    public int InUse { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
