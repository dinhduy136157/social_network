using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class User
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Avatar { get; set; }

    public DateOnly Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime RegisterAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Group> GroupCreatedByNavigations { get; set; } = new List<Group>();

    public virtual ICollection<GroupFollower> GroupFollowers { get; set; } = new List<GroupFollower>();

    public virtual ICollection<GroupPostComment> GroupPostComments { get; set; } = new List<GroupPostComment>();

    public virtual ICollection<GroupPostLike> GroupPostLikes { get; set; } = new List<GroupPostLike>();

    public virtual ICollection<GroupPost> GroupPosts { get; set; } = new List<GroupPost>();

    public virtual ICollection<Group> GroupUpdatedByNavigations { get; set; } = new List<Group>();

    public virtual ICollection<UserFollower> UserFollowerSources { get; set; } = new List<UserFollower>();

    public virtual ICollection<UserFollower> UserFollowerTargets { get; set; } = new List<UserFollower>();

    public virtual ICollection<UserFriend> UserFriendSources { get; set; } = new List<UserFriend>();

    public virtual ICollection<UserFriend> UserFriendTargets { get; set; } = new List<UserFriend>();

    public virtual ICollection<UserMessage> UserMessageSources { get; set; } = new List<UserMessage>();

    public virtual ICollection<UserMessage> UserMessageTargets { get; set; } = new List<UserMessage>();

    public virtual ICollection<UserPostComment> UserPostComments { get; set; } = new List<UserPostComment>();

    public virtual ICollection<UserPostLike> UserPostLikes { get; set; } = new List<UserPostLike>();

    public virtual ICollection<UserPost> UserPosts { get; set; } = new List<UserPost>();
}
