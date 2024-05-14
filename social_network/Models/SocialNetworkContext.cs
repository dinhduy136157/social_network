using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace social_network.Models;

public partial class SocialNetworkContext : DbContext
{
    public SocialNetworkContext()
    {
    }

    public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupFollower> GroupFollowers { get; set; }

    public virtual DbSet<GroupMember> GroupMembers { get; set; }

    public virtual DbSet<GroupPost> GroupPosts { get; set; }

    public virtual DbSet<GroupPostComment> GroupPostComments { get; set; }

    public virtual DbSet<GroupPostLike> GroupPostLikes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFollower> UserFollowers { get; set; }

    public virtual DbSet<UserFriend> UserFriends { get; set; }

    public virtual DbSet<UserMessage> UserMessages { get; set; }

    public virtual DbSet<UserPost> UserPosts { get; set; }

    public virtual DbSet<UserPostComment> UserPostComments { get; set; }

    public virtual DbSet<UserPostLike> UserPostLikes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7BK339H;Initial Catalog=social_network;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__groups__3213E83FE876DC25");

            entity.ToTable("groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Background)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text")
                .HasColumnName("background");
            entity.Property(e => e.Content)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.ProfileDetails)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text")
                .HasColumnName("profile_details");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("slug");
            entity.Property(e => e.Title)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.GroupCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_groups_createdBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.GroupUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_groups_updatedBy");
        });

        modelBuilder.Entity<GroupFollower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group_fo__3213E83FC4C2C97C");

            entity.ToTable("group_follower");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updateAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupFollowers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_follower_groupId");

            entity.HasOne(d => d.User).WithMany(p => p.GroupFollowers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_follower_userId");
        });

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("group_member");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Role)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_member_groupId");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_member_userId");
        });

        modelBuilder.Entity<GroupPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group_po__3213E83F3B3C02C7");

            entity.ToTable("group_post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Video)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text")
                .HasColumnName("video");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupPosts)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_post_groupId");

            entity.HasOne(d => d.User).WithMany(p => p.GroupPosts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_post_userId");
        });

        modelBuilder.Entity<GroupPostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group_po__3213E83F5D8EC776");

            entity.ToTable("group_post_comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupPostId).HasColumnName("groupPostId");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.SenderId).HasColumnName("senderId");

            entity.HasOne(d => d.GroupPost).WithMany(p => p.GroupPostComments)
                .HasForeignKey(d => d.GroupPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_comment_groupPostId");

            entity.HasOne(d => d.Sender).WithMany(p => p.GroupPostComments)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_comment_senderId");
        });

        modelBuilder.Entity<GroupPostLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group_po__3213E83FDE1F8A83");

            entity.ToTable("group_post_like");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupPostId).HasColumnName("groupPostId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.GroupPost).WithMany(p => p.GroupPostLikes)
                .HasForeignKey(d => d.GroupPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_post_groupPostId");

            entity.HasOne(d => d.User).WithMany(p => p.GroupPostLikes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_post_like_userId");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("notification");

            entity.Property(e => e.ActorId).HasColumnName("actorId");
            entity.Property(e => e.GroupPostCommentId).HasColumnName("groupPostCommentId");
            entity.Property(e => e.GroupPostLikeId).HasColumnName("groupPostLikeId");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IsRead).HasColumnName("isRead");
            entity.Property(e => e.NotificationDate)
                .HasColumnType("datetime")
                .HasColumnName("notificationDate");
            entity.Property(e => e.NotificationText).HasColumnName("notificationText");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .HasColumnName("notificationType");
            entity.Property(e => e.RequestFriendId).HasColumnName("requestFriendId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.UserPostCommentId).HasColumnName("userPostCommentId");
            entity.Property(e => e.UserPostLikeId).HasColumnName("userPostLikeId");

            entity.HasOne(d => d.Actor).WithMany()
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noti_actorId");

            entity.HasOne(d => d.GroupPostComment).WithMany()
                .HasForeignKey(d => d.GroupPostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noti_groupPostCommentId");

            entity.HasOne(d => d.GroupPostLike).WithMany()
                .HasForeignKey(d => d.GroupPostLikeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noti_groupPostLikeId");

            entity.HasOne(d => d.RequestFriend).WithMany()
                .HasForeignKey(d => d.RequestFriendId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noti_requestFriendId");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noti_userId");

            entity.HasOne(d => d.UserPostComment).WithMany()
                .HasForeignKey(d => d.UserPostCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noti_userPostCommentId");

            entity.HasOne(d => d.UserPostLike).WithMany()
                .HasForeignKey(d => d.UserPostLikeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noti_userPostLikeId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FBB463096");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "uq_email").IsUnique();

            entity.HasIndex(e => e.Phone, "uq_phone").IsUnique();

            entity.HasIndex(e => e.UserName, "uq_username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasColumnType("text")
                .HasColumnName("avatar");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("lastLogin");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middleName");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("passwordHash");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RegisterAt)
                .HasColumnType("datetime")
                .HasColumnName("registerAt");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<UserFollower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_fol__3213E83F009CEA08");

            entity.ToTable("user_follower");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.SourceId).HasColumnName("sourceId");
            entity.Property(e => e.TargetId).HasColumnName("targetId");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            entity.HasOne(d => d.Source).WithMany(p => p.UserFollowerSources)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_follower_source");

            entity.HasOne(d => d.Target).WithMany(p => p.UserFollowerTargets)
                .HasForeignKey(d => d.TargetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_follower_target");
        });

        modelBuilder.Entity<UserFriend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_fri__3213E83FAC1D64C7");

            entity.ToTable("user_friend");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.SourceId).HasColumnName("sourceId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TargetId).HasColumnName("targetId");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Source).WithMany(p => p.UserFriendSources)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_friend_source");

            entity.HasOne(d => d.Target).WithMany(p => p.UserFriendTargets)
                .HasForeignKey(d => d.TargetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_friend_target");
        });

        modelBuilder.Entity<UserMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_mes__3213E83F72F6C20A");

            entity.ToTable("user_message");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Message)
                .HasDefaultValue("")
                .HasColumnName("message");
            entity.Property(e => e.SourceId).HasColumnName("sourceId");
            entity.Property(e => e.TargetId).HasColumnName("targetId");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            entity.HasOne(d => d.Source).WithMany(p => p.UserMessageSources)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_message_source");

            entity.HasOne(d => d.Target).WithMany(p => p.UserMessageTargets)
                .HasForeignKey(d => d.TargetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_message_target");
        });

        modelBuilder.Entity<UserPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_pos__3213E83F9863FA54");

            entity.ToTable("user_post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Video)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text")
                .HasColumnName("video");

            entity.HasOne(d => d.User).WithMany(p => p.UserPosts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_post_userId");
        });

        modelBuilder.Entity<UserPostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_pos__3213E83F3FE05E7C");

            entity.ToTable("user_post_comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.UserPostId).HasColumnName("userPostId");

            entity.HasOne(d => d.Sender).WithMany(p => p.UserPostComments)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_comment_senderId");

            entity.HasOne(d => d.UserPost).WithMany(p => p.UserPostComments)
                .HasForeignKey(d => d.UserPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_comment_userPostId");
        });

        modelBuilder.Entity<UserPostLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_pos__3213E83FBB5A8395");

            entity.ToTable("user_post_like");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PostId).HasColumnName("postId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Post).WithMany(p => p.UserPostLikes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_post_like_postId");

            entity.HasOne(d => d.User).WithMany(p => p.UserPostLikes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_post_like_userId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
