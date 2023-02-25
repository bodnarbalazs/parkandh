using System;
using System.Collections.Generic;

namespace KHBackend.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PrivateParking { get; set; }

    public string Password { get; set; } = null!;

    public string? HomeAddress { get; set; }

    public int Coin { get; set; }

    public string? UserSettings { get; set; }

    public virtual ICollection<CarPool> CarPools { get; } = new List<CarPool>();

    public virtual ICollection<ParkRequest> ParkRequests { get; } = new List<ParkRequest>();

    public virtual ICollection<ParkingReservation> ParkingReservationOwners { get; } = new List<ParkingReservation>();

    public virtual ICollection<ParkingReservation> ParkingReservationSurrogatedNavigations { get; } = new List<ParkingReservation>();
}
