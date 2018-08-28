using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDemoBlog26.Areas.Product.Models;

namespace WebAppDemoBlog26.Areas.Product.Controllers
{
    public class ItemController : Controller
    {
        // GET: Product/Item
        public ActionResult Index()
        {

            IEnumerable<Item> items = new List<Item>() {
            new Item { Id=1,Code="0001", Name="Spoon"},
            new Item { Id=2,Code="0002", Name="Hammer"},
            new Item { Id=3,Code="0003", Name="Basket"},
            new Item { Id=4,Code="0004", Name="Disk"},
            new Item { Id=5,Code="0005", Name="Sponge"}
            };

            return View(items);
        }
    }
}