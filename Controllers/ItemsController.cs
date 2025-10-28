using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;

namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems iAllItems, ICategorys iAllCategorys, IHostingEnvironment environment)
        {
            this.IAllItems = iAllItems;
            this.IAllCategorys = iAllCategorys;
            hostingEnvironment = environment;
        }

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Categorys = IAllCategorys.AllCategorys;
            VMItems.SelectCategory = id;

            return View(VMItems);
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
        public ActionResult Basket(int idItem)
        {
            return Json(true);
        }
    }
}