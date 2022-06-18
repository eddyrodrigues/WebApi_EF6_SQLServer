using Blog.Domain.Entities;
using Blog.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository.Context;

public class BlogDbContext : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Post> Posts { get; set; }
  
  
  public BlogDbContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder){
    modelBuilder.ApplyConfiguration(new PostMap());
    modelBuilder.ApplyConfiguration(new CategoryMap());
  }
}