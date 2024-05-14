using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class UserPostLike
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long PostId { get; set; }

    public virtual UserPost Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
