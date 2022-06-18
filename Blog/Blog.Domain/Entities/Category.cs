namespace Blog.Domain.Entities;

public class Category : BaseEntity
{
  public Category(string name, string slug)
  {
    Name = name;
    Slug = slug;
  }

  public string Name { get; private set; }
  public string Slug { get; private set; }
  public List<Post> Posts { get; set; } = new List<Post>();
}