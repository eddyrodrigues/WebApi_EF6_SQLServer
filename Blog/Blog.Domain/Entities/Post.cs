namespace Blog.Domain.Entities;

public class Post : BaseEntity
{
  public Post(string title, string text)
  {
    Title = title;
    Text = text;
    // TODO: Add contract here
  }

  public string Title { get; private set; }
  public string Text { get; private set; }
  public List<Category> Category { get; private set; }
  
}