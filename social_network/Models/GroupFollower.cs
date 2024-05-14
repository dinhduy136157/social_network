using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class GroupFollower
{
    public long Id { get; set; }

    public long GroupId { get; set; }

    public long UserId { get; set; }

    public short Type { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
