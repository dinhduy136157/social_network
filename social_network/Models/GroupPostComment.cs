using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class GroupPostComment
{
    public long Id { get; set; }

    public long GroupPostId { get; set; }

    public long SenderId { get; set; }

    public string Message { get; set; } = null!;

    public virtual GroupPost GroupPost { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
