using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Repository.Mapping;

public class PostMap : IEntityTypeConfiguration<Post>
{
  public void Configure(EntityTypeBuilder<Post> builder)
  {
    builder.ToTable("Posts");

    builder.HasKey(c => c.Id);

    builder.Property(c => c.Id)
           .ValueGeneratedOnAdd();

    builder.Property(c => c.Title).HasColumnType("varchar").HasMaxLength(255);
    builder.Property(c => c.Text).HasColumnType("varchar(max)");

    builder.Ignore(t => t.Notifications);
    builder.Ignore(t => t.IsValid);
  }
}