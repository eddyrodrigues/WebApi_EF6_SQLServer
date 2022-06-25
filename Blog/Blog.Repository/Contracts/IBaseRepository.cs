using Blog.Domain.Entities;

namespace Blog.Repository.Contracts;

public interface IBaseRepository<T>
{
  public Category GetByGuid(Guid guid);
  public List<T> GetAll();
}
