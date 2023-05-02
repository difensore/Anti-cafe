using System;
using System.Collections.Generic;

namespace Anti_Cafe.DAL.Models;

public partial class Table
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Statuette { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual Statuette? StatuetteNavigation { get; set; }
}
