using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Components {
  public class ProdottoCard : ViewComponent {
    public ProdottoCard () { }

    public async Task<IViewComponentResult> InvokeAsync () {
      return View ();
    }
  }
}