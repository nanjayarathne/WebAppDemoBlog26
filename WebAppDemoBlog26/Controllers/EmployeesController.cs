using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppDemoBlog26.Models;
using PagedList;
using WebAppDemoBlog26.Areas.Product.Models;

namespace WebAppDemoBlog26.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: Employees
        //[OutputCache(Duration =10)]
        public ActionResult Index(string searchBy,string search,int?page,string sortBy)
        {
            //throw new Exception("unknown eroor!!");
            //test
            //IEnumerable<DataRow> query = (IEnumerable<DataRow>)(from e in db.Employees select e);
            //DataSet ds = new DataSet();
            //ds.Tables.Add(query.CopyToDataTable<DataRow>());

            //

            var employees = db.Employees.Include(e => e.Department).AsQueryable();

            ViewBag.SortByName = string.IsNullOrEmpty(sortBy) ? "Name Desc" : "";
            ViewBag.SortByGender = sortBy == "Gender" ? "Gender Desc" : "Gender";

            switch (sortBy)
            {
                case "Name Desc":
                    employees = employees.OrderByDescending(p => p.Name);
                    break;
                case "Gender Desc":
                    employees = employees.OrderByDescending(p => p.Gender);
                    break;

                default:
                    employees = employees.OrderBy(p => p.Name);
                    break;

            }

            return View(employees.ToPagedList(page??1,10));
        }


        [RequireHttps]
        public string secureMethod()
        {
            return "this need https request";
        }
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {

            if (db.Employees.Any(e => e.Name == employee.Name))
            {
                ModelState.AddModelError("Name", "Already in Use");
            }

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }


        public JsonResult IsNameEnable(string Name)
        {
            return Json(!db.Employees.Any(e => e.Name == Name),JsonRequestBehavior.AllowGet);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {

          

            db.Employees.Where(x => employeeIdsToDelete.Contains(x.EmployeeId)).ToList().ForEach(p => db.Employees.Remove(p));
            db.SaveChanges();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Employee employee = db.Employees.Find(id);
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}
            return RedirectToAction("Index");
        }

        // POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    db.Employees.Remove(employee);
        //    db.SaveChanges();
        //    return RedirectToAction("Index","Employees");
        //}
        [ValidateInput(false)]
            public ActionResult Index1(string comments)
        {
            
            return View();
        }

        public PartialViewResult All()
        {
            IEnumerable<Employee> model = db.Employees.ToList();

            return PartialView("_EmployeePartialView",model);
        }

        public PartialViewResult Top()
        {
            IEnumerable<Employee> model = db.Employees.ToList().Take(3).Skip(0);

            return PartialView("_EmployeePartialView", model);
        }

        public PartialViewResult Bottom()
        {
            IEnumerable<Employee> model = db.Employees.ToList().Take(3).Skip(db.Employees.Count()-3);

            return PartialView("_EmployeePartialView", model);
        }


        public JsonResult AutoCompleteStudent(string term)
        {
            IEnumerable<string> list = db.Employees.Where(x => x.Name.StartsWith(term)).Select(p => p.Name).ToList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
