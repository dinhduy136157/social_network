using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class Notification
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long ActorId { get; set; }

    public long UserPostCommentId { get; set; }

    public long GroupPostCommentId { get; set; }

    public long UserPostLikeId { get; set; }

    public long GroupPostLikeId { get; set; }

    public long RequestFriendId { get; set; }

    public string? NotificationType { get; set; }

    public string? NotificationText { get; set; }

    public DateTime? NotificationDate { get; set; }

    public bool? IsRead { get; set; }

    public virtual User Actor { get; set; } = null!;

    public virtual GroupPostComment GroupPostComment { get; set; } = null!;

    public virtual GroupPostLike GroupPostLike { get; set; } = null!;

    public virtual UserFriend RequestFriend { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual UserPostComment UserPostComment { get; set; } = null!;

    public virtual UserPostLike UserPostLike { get; set; } = null!;
}
