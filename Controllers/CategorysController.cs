using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class CategorysController : Controller
    {
        private ICategorys IAllCategorys;

        public CategorysController(ICategorys iAllCategorys)
        {
            IAllCategorys = iAllCategorys;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Категории товаров";
            return View(IAllCategorys.AllCategorys);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(string name, string description)
        {
            IAllCategorys.Add(new Categorys()
            {
                Name = name,
                Description = description
            });
            return Redirect("/Categorys/List");
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            return View(IAllCategorys.GetCategoryById(id));
        }

        [HttpPost]
        public RedirectResult Update(int id, string name, string description)
        {
            IAllCategorys.Update(new Categorys()
            {
                Id = id,
                Name = name,
                Description = description
            });
            return Redirect("/Categorys/List");
        }

        public RedirectResult Delete(int id)
        {
            IAllCategorys.Delete(id);
            return Redirect("/Categorys/List");
        }
    }
}