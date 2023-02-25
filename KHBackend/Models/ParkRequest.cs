using System;
using System.Collections.Generic;

namespace KHBackend.Models;

public partial class ParkRequest
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public virtual User? User { get; set; }
}
