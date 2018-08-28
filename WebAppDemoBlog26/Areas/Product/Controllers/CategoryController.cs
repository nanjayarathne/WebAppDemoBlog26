using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDemoBlog26.Areas.Product.Models;

namespace WebAppDemoBlog26.Areas.Product.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Product/Category
        public ActionResult Index()
        {


            IEnumerable<Category> categories = new List<Category>() {
            new Category { Id=1, Name="Spoon"},
            new Category { Id=2, Name="Hammer"},
            new Category { Id=3, Name="Basket"},
            new Category { Id=4, Name="Disk"},
            new Category { Id=5, Name="Sponge"}
            };
            return View(categories);
        }

        public ActionResult Create()
        {
            Category cat = new Category() { Id = 1, Name = "cat" };
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                //db.Employees.Add(employee);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(model);
        }
    }
}