using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class GroupMember
{
    public long Id { get; set; }

    public long GroupId { get; set; }

    public long UserId { get; set; }

    public short? Role { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
