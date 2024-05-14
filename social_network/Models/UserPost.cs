using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class UserPost
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public string? Video { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserPostComment> UserPostComments { get; set; } = new List<UserPostComment>();

    public virtual ICollection<UserPostLike> UserPostLikes { get; set; } = new List<UserPostLike>();
}
