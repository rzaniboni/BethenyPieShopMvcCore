using System.Collections.Generic;

namespace BethanyPieShop.Models {
  public class CategoryRepository : ICategoryRepository {
    private readonly AppDbContext _context;

    public CategoryRepository (AppDbContext context) {
      this._context = context;
    }

    public IEnumerable<Category> AllCategories {
      get {
        return _context.Categories;
      }
    }
  }
}