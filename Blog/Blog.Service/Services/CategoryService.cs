using Blog.Domain.Arguments;
using Blog.Domain.Entities;
using Blog.Repository.Contracts;
using Blog.Repository.Filters;
using Blog.Repository.Repositories;

namespace Blog.Service.Services;

public class CategoryService {
  private readonly CategoryRepository _categoryRepository;

  public CategoryService(CategoryRepository CategoryRepository)
  {
    _categoryRepository = CategoryRepository;
  }

  public List<Category> GetAllCategories()
  {
    return _categoryRepository.GetAll();
  }

  public Category AddCategory(CategoryArgument categoryArgument)
  {
    var newCategory = new Category(categoryArgument.Name, categoryArgument.Slug);

    if (!newCategory.IsValid)
      return newCategory;

    return _categoryRepository.AddCategory(newCategory);
  }
}