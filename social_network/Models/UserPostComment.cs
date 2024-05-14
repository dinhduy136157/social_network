using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class UserPostComment
{
    public long Id { get; set; }

    public long UserPostId { get; set; }

    public long SenderId { get; set; }

    public string? Message { get; set; }

    public virtual User Sender { get; set; } = null!;

    public virtual UserPost UserPost { get; set; } = null!;
}
