using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Repository.Mapping;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("Categorias");

    builder.HasKey(c => c.Id);

    builder.Property(c => c.Id)
           .ValueGeneratedOnAdd();

    builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(255);
    builder.Property(c => c.Slug).HasColumnType("varchar").HasMaxLength(255);

    builder.HasMany(c => c.Posts)
      .WithMany(p => p.Category)
      .UsingEntity<Dictionary<string, object>>(
        "CategoryPost",
        cat => cat.HasOne<Post>()
                  .WithMany()
                  .HasForeignKey("CategoryId")
                  .HasConstraintName("FK_CategoryPost_CategoryId"),
        post => post.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("PostId")
                    .HasConstraintName("FK_PostCategory_PostId")
      );


    // Índices
    builder
        .HasIndex(x => x.Slug, "IX_Category_Slug")
        .IsUnique();


    builder.Ignore(t => t.Notifications);
    builder.Ignore(t => t.IsValid);
  }
}