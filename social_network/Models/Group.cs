using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class Group
{
    public long Id { get; set; }

    public long CreatedBy { get; set; }

    public long UpdatedBy { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ProfileDetails { get; set; }

    public string? Content { get; set; }

    public string? Background { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<GroupFollower> GroupFollowers { get; set; } = new List<GroupFollower>();

    public virtual ICollection<GroupPost> GroupPosts { get; set; } = new List<GroupPost>();

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
