using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers {
  public class PieController : Controller {
    private readonly IPieRepository _pieRepository;
    private readonly ICategoryRepository _categoryRepository;

    public PieController (IPieRepository pieRepository, ICategoryRepository categoryRepository) {
      this._pieRepository = pieRepository;
      this._categoryRepository = categoryRepository;
    }

    public ViewResult List () { // action
      ViewBag.Message = "Welcome to Bethany's Pie Shop";
      ViewBag.CurrentCategory = "Cheese cakes";

      var pieVM = new PiesListViewModel
      {
        CurrentCategory = "Cheese cakes",
        Pies = _pieRepository.AllPies
      };

      return View (pieVM); // view to show
    }
  }
}