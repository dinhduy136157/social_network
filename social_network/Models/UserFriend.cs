using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class UserFriend
{
    public long Id { get; set; }

    public long SourceId { get; set; }

    public long TargetId { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Source { get; set; } = null!;

    public virtual User Target { get; set; } = null!;
}
