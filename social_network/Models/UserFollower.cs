using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class UserFollower
{
    public long Id { get; set; }

    public long SourceId { get; set; }

    public long TargetId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual User Source { get; set; } = null!;

    public virtual User Target { get; set; } = null!;
}
