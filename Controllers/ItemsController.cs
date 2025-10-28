using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        
        private IItems IAllItems;
        private ICategorys IAllCategorys;

        public ItemsController(IItems iAllItems, ICategorys iAllCategorys, IHostingEnvironment environment)
        {
            IAllItems = iAllItems;
            IAllCategorys = iAllCategorys;
            hostingEnvironment = environment;
        }

        public ViewResult List(int id = 0, string sort = "", string search = "")
        {
            ViewBag.Title = "Страница с предметами";

            var items = string.IsNullOrEmpty(search)
                ? IAllItems.AllItems
                : IAllItems.FindItems(search);

            switch (sort)
            {
                case "asc":
                    items = items.OrderBy(i => i.Price);
                    break;
                case "desc":
                    items = items.OrderByDescending(i => i.Price);
                    break;
            }

            if (id != 0)
            {
                items = items.Where(i => i.Category.Id == id);
            }

            var vmItems = new VMItems
            {
                Items = items,
                Categorys = IAllCategorys.AllCategorys,
                SelectCategory = id
            };

            return View(vmItems);
        }
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categorys> Categorys = IAllCategorys.AllCategorys;
            return View(Categorys);
        }
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Image = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categorys() { Id = idCategory };
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);
        }
        [HttpGet]
        public ViewResult Update(int id)
        {
            var item = IAllItems.GetItemById(id);
            ViewBag.Categories = IAllCategorys.AllCategorys;
            return View(item);
        }

        [HttpPost]
        public RedirectResult Update(int id, string name, string description, IFormFile files, float price, int idCategory)
        {
            var item = IAllItems.GetItemById(id);

            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
                item.Image = files.FileName;
            }

            item.Name = name;
            item.Description = description;
            item.Price = Convert.ToInt32(price);
            item.Category = new Categorys() { Id = idCategory };

            IAllItems.Update(item);
            return Redirect("/Items/List");
        }

        public RedirectResult Delete(int id)
        {
            IAllItems.Delete(id);
            return Redirect("/Items/List");
        }

        public ActionResult Basket(int idItem = -1)
        {
            if (idItem != -1)
            {
                Startup.BasketItem.Add(new ItemsBasket(1,IAllItems.AllItems.Where(x => x.Id == idItem).First()));
            }
            return Json(Startup.BasketItem);
        }
        public ActionResult BasketCount(int idItem = -1, int count = -1)
        {
            if (idItem != -1)
            {
                if (count == 0)
                {
                    Startup.BasketItem.Remove(Startup.BasketItem.Find(x => x.Id == idItem));
                }
                else
                    Startup.BasketItem.Find(x => x.Id == idItem).Count = count;
            }
            return Json(Startup.BasketItem);
        }
    }
}