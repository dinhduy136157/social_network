using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class GroupPostLike
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long GroupPostId { get; set; }

    public virtual GroupPost GroupPost { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
