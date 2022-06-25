using Blog.Domain.Entities;
using Blog.Repository.Context;
using Blog.Repository.Contracts;

namespace Blog.Repository.Repositories;

public class CategoryRepository : IBaseRepository<Category>
{
  private readonly BlogDbContext _context;

  public CategoryRepository(BlogDbContext context)
  {
    _context = context;
  }

  public List<Category> GetAll()
  {
    return _context.Set<Category>().ToList();
  }

  public Category GetByGuid(Guid guid)
  {
    return _context.Set<Category>().Find(guid);
  }

  public Category AddCategory(Category category)
  {
    _context.Set<Category>().Add(category);
    int affectedRows = _context.SaveChanges();
    return category;
  }
}
