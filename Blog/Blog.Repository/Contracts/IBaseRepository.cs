using Blog.Domain.Entities;

namespace Blog.Repository.Contracts;

public interface IBaseRepository
{
  public Category GetByGuid(Guid guid);
  public List<Category> GetAll();
}