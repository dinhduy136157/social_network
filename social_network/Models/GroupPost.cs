using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class GroupPost
{
    public long Id { get; set; }

    public long GroupId { get; set; }

    public long UserId { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public string? Video { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<GroupPostComment> GroupPostComments { get; set; } = new List<GroupPostComment>();

    public virtual ICollection<GroupPostLike> GroupPostLikes { get; set; } = new List<GroupPostLike>();

    public virtual User User { get; set; } = null!;
}
