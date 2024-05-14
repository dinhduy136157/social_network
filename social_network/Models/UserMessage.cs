using System;
using System.Collections.Generic;

namespace social_network.Models;

public partial class UserMessage
{
    public long Id { get; set; }

    public long SourceId { get; set; }

    public long TargetId { get; set; }

    public string? Message { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual User Source { get; set; } = null!;

    public virtual User Target { get; set; } = null!;
}
