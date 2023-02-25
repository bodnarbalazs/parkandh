using System;
using System.Collections.Generic;

namespace KHBackend.Models;

public partial class CarPool
{
    public int Id { get; set; }

    public int DriverId { get; set; }

    public int Limit { get; set; }

    public DateTime Date { get; set; }

    public virtual User Driver { get; set; } = null!;
}
