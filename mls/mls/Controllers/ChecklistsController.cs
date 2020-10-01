using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    [Authorize]
    public class ChecklistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checklists
        public ActionResult Index()
        {
            var query = from a in db.Checklists
                        select a;
            return View("Index", query);
        }

        // GET: Checklists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = await db.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // GET: Checklists/Create
        public ActionResult Create()
        {
            var departments = db.Departments.ToList();
            var employees = db.Employees.ToList();
            var checklisttypes = db.ChecklistTypes.ToList();

            var viewModel = new SaveChecklistViewModel()
            {

                Departments = departments,
                Employees = employees,
                ChecklistTypes = checklisttypes

            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: Checklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "ChecklistId,DepartmentId,ChecklistTypeId,EmployeeId,Action,Notes")] Checklist checklist)
        public async Task<ActionResult> Create(Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                db.Checklists.Add(checklist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", checklist);
            }

            return View(checklist);
        }

        // GET: Checklists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var checklists = db.Checklists.SingleOrDefault(c => c.ChecklistId == id);

            var departments = db.Departments.ToList();
            var employees = db.Employees.ToList();
            var checklisttypes = db.ChecklistTypes.ToList();

            var viewModel = new SaveChecklistViewModel()
            {
                Checklist = checklists,
                Departments = departments,
                Employees = employees,
                ChecklistTypes = checklisttypes
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = await db.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(checklist);
        }

        // POST: Checklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "ChecklistId,DepartmentId,ChecklistTypeId,EmployeeId,Action,Notes")] Checklist checklist)
        public async Task<ActionResult> Edit(Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checklist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", checklist);
            }
            return View(checklist);
        }

        // GET: Checklists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = await db.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // POST: Checklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Checklist checklist = await db.Checklists.FindAsync(id);
            db.Checklists.Remove(checklist);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult _ChecklistDaily(int department)
        {
            var queryNew = from a in db.Checklists
                           where a.ChecklistTypeId == 1 && a.DepartmentId == department
                           select a;
            List<NewChecklistViewModel> result = new List<NewChecklistViewModel>();
            foreach (var check in queryNew.ToList())
            {
                result.Add(new NewChecklistViewModel
                {
                    ChecklistId = check.ChecklistId,
                    Employee = check.EmployeeId,
                    ChecklistAction = check.ChecklistAction,
                    Notes = check.Notes
                });
            }
            return PartialView("_ChecklistDaily", result);
        }

        public ActionResult _ChecklistWeekly(int department)
        {
            var queryNew = from a in db.Checklists
                           where a.ChecklistTypeId == 2 && a.DepartmentId == department
                           select a;
            List<NewChecklistViewModel> result = new List<NewChecklistViewModel>();
            foreach (var check in queryNew.ToList())
            {
                result.Add(new NewChecklistViewModel
                {
                    ChecklistId = check.ChecklistId,
                    Employee = check.EmployeeId,
                    ChecklistAction = check.ChecklistAction,
                    Notes = check.Notes
                });
            }
            return PartialView("_ChecklistWeekly", result);
        }

        public ActionResult _ChecklistBiWeekly(int department)
        {
            var queryNew = from a in db.Checklists
                           where a.ChecklistTypeId == 3 && a.DepartmentId == department
                           select a;
            List<NewChecklistViewModel> result = new List<NewChecklistViewModel>();
            foreach (var check in queryNew.ToList())
            {
                result.Add(new NewChecklistViewModel
                {
                    ChecklistId = check.ChecklistId,
                    Employee = check.EmployeeId,
                    ChecklistAction = check.ChecklistAction,
                    Notes = check.Notes
                });
            }
            return PartialView("_ChecklistBiWeekly", result);
        }

        public ActionResult _ChecklistMonthly(int department)
        {
            var queryNew = from a in db.Checklists
                           where a.ChecklistTypeId == 4 && a.DepartmentId == department
                           select a;
            List<NewChecklistViewModel> result = new List<NewChecklistViewModel>();
            foreach (var check in queryNew.ToList())
            {
                result.Add(new NewChecklistViewModel
                {
                    ChecklistId = check.ChecklistId,
                    Employee = check.EmployeeId,
                    ChecklistAction = check.ChecklistAction,
                    Notes = check.Notes
                });
            }
            return PartialView("_ChecklistMonthly", result);
        }

        public ActionResult _ChecklistQuarterly(int department)
        {
            var queryNew = from a in db.Checklists
                           where a.ChecklistTypeId == 5 && a.DepartmentId == department
                           select a;
            List<NewChecklistViewModel> result = new List<NewChecklistViewModel>();
            foreach (var check in queryNew.ToList())
            {
                result.Add(new NewChecklistViewModel
                {
                    ChecklistId = check.ChecklistId,
                    Employee = check.EmployeeId,
                    ChecklistAction = check.ChecklistAction,
                    Notes = check.Notes
                });
            }
            return PartialView("_ChecklistQuarterly", result);
        }

        public ActionResult _ChecklistSemiAnnually(int department)
        {
            var queryNew = from a in db.Checklists
                           where a.ChecklistTypeId == 6 && a.DepartmentId == department
                           select a;
            List<NewChecklistViewModel> result = new List<NewChecklistViewModel>();
            foreach (var check in queryNew.ToList())
            {
                result.Add(new NewChecklistViewModel
                {
                    ChecklistId = check.ChecklistId,
                    Employee = check.EmployeeId,
                    ChecklistAction = check.ChecklistAction,
                    Notes = check.Notes
                });
            }
            return PartialView("_ChecklistSemiAnnually", result);
        }

        public ActionResult _ChecklistAnnually(int department)
        {
            var queryNew = from a in db.Checklists
                           where a.ChecklistTypeId == 7 && a.DepartmentId == department
                           select a;
            List<NewChecklistViewModel> result = new List<NewChecklistViewModel>();
            foreach (var check in queryNew.ToList())
            {
                result.Add(new NewChecklistViewModel
                {
                    ChecklistId = check.ChecklistId,
                    Employee = check.EmployeeId,
                    ChecklistAction = check.ChecklistAction,
                    Notes = check.Notes
                });
            }
            return PartialView("_ChecklistAnnually", result);
        }

        public ActionResult Ops()
        {
            return View("Ops");
        }

        public ActionResult Exec()
        {
            return View("Exec");
        }

        public ActionResult Quality()
        {
            return View("Quality");
        }

        public ActionResult SupplyChain()
        {
            return View("SupplyChain");
        }

        public ActionResult Logistics()
        {
            return View("Logistics");
        }

        public ActionResult Eng()
        {
            return View("Eng");
        }

        public ActionResult Sales()
        {
            return View("Sales");
        }

        public ActionResult HR()
        {
            return View("HR");
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
