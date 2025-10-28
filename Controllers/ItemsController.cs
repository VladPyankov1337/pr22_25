using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.ViewModell;

namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems iAllItems, ICategorys iAllCategorys)
        {
            this.IAllItems = iAllItems;
            this.IAllCategorys = iAllCategorys;
        }

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Categorys = IAllCategorys.AllCategorys;
            VMItems.SelectCategory = id;

            return View(VMItems);
        }
    }
}