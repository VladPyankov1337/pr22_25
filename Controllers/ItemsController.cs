using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;

namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;

        public ItemsController(IItems iAllItems, ICategorys iAllCategorys)
        {
            IAllItems = iAllItems;
            IAllCategorys = iAllCategorys;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с предметами";
            var cars = IAllItems.AllItems;
            return View(cars);
        }
    }
}
