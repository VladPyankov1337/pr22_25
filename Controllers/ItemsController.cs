using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;
using System;
using System.Collections.Generic;
using System.IO;

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

        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categorys> Categorys = IAllCategorys.AllCategorys;
            return View(Categorys);
        }
    }
}