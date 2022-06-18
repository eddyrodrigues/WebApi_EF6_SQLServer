using Flunt.Notifications;
using Flunt.Validations;

namespace Blog.Domain.Arguments;

public class CategoryArgument: Notifiable<Notification>
{
  public CategoryArgument(string name, string slug)
  {
    Name = name;
    Slug = slug;
    // Fail Fast Validations
    AddNotifications(new Contract<string>()
                        .IsNotNull(name, "Category.Name", "Name cannot by null")
                        .IsNotNull(slug, "Category.Slug", "slug cannot by null")
                        .IsGreaterThan(name, 3, "Category.Name", "Name cannot have less than 3 chars")
                        .IsGreaterThan(slug, 3, "Category.Slug", "Name cannot have less than 3 chars")
    );
  }

  public string Name { get; set; }
  public string Slug { get; set; }
  
  
}