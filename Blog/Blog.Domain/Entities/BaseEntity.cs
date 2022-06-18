using Flunt.Notifications;

namespace Blog.Domain.Entities;

public class BaseEntity : Notifiable<Notification>
{
  public Guid Id { get; private set; }

  public BaseEntity()
  {
    Id = Guid.NewGuid();
  }
}