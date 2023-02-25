using System;
using System.Collections.Generic;

namespace KHBackend.Models;

public partial class ParkingReservation
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public int? Surrogated { get; set; }

    public virtual User? Owner { get; set; }

    public virtual User? SurrogatedNavigation { get; set; }
}
