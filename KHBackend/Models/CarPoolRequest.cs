using System;
using System.Collections.Generic;

namespace KHBackend.Models;

public partial class CarPoolRequest
{
    public int UserId { get; set; }

    public int CarPoolId { get; set; }

    public virtual CarPool CarPool { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
