using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    [Authorize]
    public class ScrumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scrums
        public ActionResult Index(int? id)
        {
            var viewModel = new ScrumIndexDataViewModel();
            viewModel.Scrums = db.Scrums
                .Include(i => i.ScrumDetails);

            if (id != null)
            {
                ViewBag.ScrumId = id.Value;
                viewModel.ScrumDetails = viewModel.Scrums.Single(
                    i => i.ScrumId == id.Value).ScrumDetails;
            }

            /*var query = from a in db.Scrums
                        where a.ScrumStatusId != 10
                        orderby a.DueDateTime ascending
                        select a;*/
            return View(viewModel);
            //return View(query.ToList());
        }

        // GET: Inventory
        public ActionResult Inventory()
        {
            return View();
        }

        // GET: Quality
        public ActionResult Quality()
        {
            return View();
        }

        // GET: Sales
        public ActionResult Sales()
        {
            return View();
        }

        // GET: Executive
        public ActionResult Executive()
        {
            return View();
        }

        // GET: IT
        public ActionResult It()
        {
            return View();
        }

        // GET: Maintenance
        public ActionResult ScrumTracker(int? id)
        {
            var viewModel = new ScrumIndexDataViewModel();
            viewModel.Scrums = db.Scrums
                .Include(i => i.ScrumDetails);

            if (id != null)
            {
                ViewBag.ScrumId = id.Value;
                viewModel.ScrumDetails = viewModel.Scrums.Single(
                    i => i.ScrumId == id.Value).ScrumDetails;
            }
            return View(viewModel);
        }


        // GET: Maintenance
        public ActionResult Maintenance()
        {
            return View();
        }

        // GET: Sc
        public ActionResult Sc()
        {
            return View();
        }

        // GET: Finance
        public ActionResult Finance()
        {
            return View();
        }

        // GET: Engineering
        public ActionResult Engineering()
        {
            return View();
        }

        // GET: Logistics
        public ActionResult Logistics()
        {
            return View();
        }

        // GET: Production
        public ActionResult Production()
        {
            return View();
        }

        // GET: ScrumHome
        public ActionResult ScrumHome(int? id)
        {
            var viewModel = new ScrumIndexDataViewModel();
            viewModel.Scrums = db.Scrums
                .Include(i => i.ScrumDetails);

            if (id != null)
            {
                ViewBag.ScrumId = id.Value;
                viewModel.ScrumDetails = viewModel.Scrums.Single(
                    i => i.ScrumId == id.Value).ScrumDetails;
            }
            return View(viewModel);
            //var query = from a in db.Scrums
            //            where a.ClassificationId != 4
            //            orderby a.DueDateTime ascending
            //            select a;
            //return View(query.ToList());
        }
        
        // GET: Scrums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scrum scrum = db.Scrums.Find(id);
            if (scrum == null)
            {
                return HttpNotFound();
            }
            return View(scrum);
        }

        // GET: Scrums/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var departments = db.Departments.ToList();
            var scrumstatuses = db.ScrumStatuses.ToList();
            var classifications = db.Classifications.ToList();
            var scrumcreatedbys = db.ScrumCreatedBies.ToList();
            var scrumresponsibles = db.ScrumResponsibles.ToList();

            var viewModel = new SaveScrumViewModel()
            {
                Departments = departments,
                ScrumStatuses = scrumstatuses,
                Classifications = classifications,
                ScrumCreatedBies = scrumcreatedbys,
                ScrumResponsibles = scrumresponsibles
            };

            return View("Create", viewModel);
            //return View();

        }

        // POST: Scrums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ScrumId,CreatedBy,CreationDateTime,Responsible,Task,Action,DueDateTime,CompletionDateTime,Notes")] Scrum scrum)
        public ActionResult Create(Scrum scrum, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Scrums.Add(scrum);
                db.SaveChanges();
                //var creator = new ScrumCreatedBy();
                //creator.
                return Redirect(returnUrl);
                //System.Net.Mail.MailMessage m = System.Net.Mail.MailMessage(
                  //new System.Net.Mail.MailAddress("", "New Scrum Assigned"),
                  //new System.Net.Mail.MailAddress())
            }

            return View();
            //return View(scrum);
        }

        // GET: Scrums/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var scrums = db.Scrums.SingleOrDefault(c => c.ScrumId == id);

            var departments = db.Departments.ToList();
            var scrumstatuses = db.ScrumStatuses.ToList();
            var classifications = db.Classifications.ToList();
            var scrumcreatedbys = db.ScrumCreatedBies.ToList();
            var scrumresponsibles = db.ScrumResponsibles.ToList();

            var viewModel = new SaveScrumViewModel()
            {
                Scrum = scrums,
                Departments = departments,
                ScrumStatuses = scrumstatuses,
                Classifications = classifications,
                ScrumCreatedBies = scrumcreatedbys,
                ScrumResponsibles = scrumresponsibles
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scrum scrum = db.Scrums.Find(id);
            if (scrum == null)
            {
                return HttpNotFound();
            }

            return View("Edit", viewModel);
            //return View(scrum);
        }

        // POST: Scrums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ScrumId,CreatedBy,CreationDateTime,Responsible,Task,Action,DueDateTime,CompletionDateTime,Notes")] Scrum scrum)
        public ActionResult Edit(Scrum scrum, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrum).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
            //return View(scrum);
        }

        // GET: Scrums/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scrum scrum = db.Scrums.Find(id);
            if (scrum == null)
            {
                return HttpNotFound();
            }
            return View(scrum);
        }

        // POST: Scrums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            Scrum scrum = db.Scrums.Find(id);
            db.Scrums.Remove(scrum);
            db.SaveChanges();
            return Redirect(returnUrl);
        }

        public ActionResult _TopPriority(int? department)
        {
            var queryNew = from a in db.Scrums
                           where a.DepartmentId == department && a.ClassificationId == 1
                           orderby a.DueDateTime descending
                           select a;
            List<NewScrumViewModel> result = new List<NewScrumViewModel>();
            foreach (var scrum in queryNew.ToList())
            {
                result.Add(new NewScrumViewModel
                {
                    ScrumId = scrum.ScrumId,
                    CreatedById = scrum.CreatedById,
                    CreationDateTime = scrum.CreationDateTime,
                    ResponsibleId = scrum.ResponsibleId,
                    DepartmentId = scrum.DepartmentId,
                    Action = scrum.Action,
                    ClassificationId = scrum.ClassificationId,
                    ScrumStatusId = scrum.ScrumStatusId,
                    DueDateTime = scrum.DueDateTime,
                    CompletionDateTime = scrum.CompletionDateTime,
                    Notes = scrum.Notes
                });
            }

            return PartialView("_TopPriorityPartialView", result);
        }


        public ActionResult _ActivelyWorking(int? department)
        {
            var queryNew = from a in db.Scrums
                           where a.DepartmentId == department && a.ClassificationId == 2
                           orderby a.DueDateTime descending
                           select a;
            List<NewScrumViewModel> result = new List<NewScrumViewModel>();
            foreach (var scrum in queryNew.ToList())
            {
                result.Add(new NewScrumViewModel
                {
                    ScrumId = scrum.ScrumId,
                    CreatedById = scrum.CreatedById,
                    CreationDateTime = scrum.CreationDateTime,
                    ResponsibleId = scrum.ResponsibleId,
                    DepartmentId = scrum.DepartmentId,
                    Action = scrum.Action,
                    ClassificationId = scrum.ClassificationId,
                    ScrumStatusId = scrum.ScrumStatusId,
                    DueDateTime = scrum.DueDateTime,
                    CompletionDateTime = scrum.CompletionDateTime,
                    Notes = scrum.Notes
                });
            }

            return PartialView("_ActivelyWorkingPartialView", result);
        }


        public ActionResult _IceBox(int? department)
        {
            var queryNew = from a in db.Scrums
                           where a.DepartmentId == department && a.ClassificationId == 3
                           orderby a.DueDateTime descending
                           select a;
            List<NewScrumViewModel> result = new List<NewScrumViewModel>();
            foreach (var scrum in queryNew.ToList())
            {
                result.Add(new NewScrumViewModel
                {
                    ScrumId = scrum.ScrumId,
                    CreatedById = scrum.CreatedById,
                    CreationDateTime = scrum.CreationDateTime,
                    ResponsibleId = scrum.ResponsibleId,
                    DepartmentId = scrum.DepartmentId,
                    Action = scrum.Action,
                    ClassificationId = scrum.ClassificationId,
                    ScrumStatusId = scrum.ScrumStatusId,
                    DueDateTime = scrum.DueDateTime,
                    CompletionDateTime = scrum.CompletionDateTime,
                    Notes = scrum.Notes
                });
            }

            return PartialView("_IceBoxPartialView", result);
        }
        
        public ActionResult _Completed(int? department)
        {
            var queryNew = from a in db.Scrums
                           where a.DepartmentId == department && a.ClassificationId == 4
                           orderby a.DueDateTime descending
                           select a;
            List<NewScrumViewModel> result = new List<NewScrumViewModel>();
            foreach (var scrum in queryNew.ToList())
            {
                result.Add(new NewScrumViewModel
                {
                    ScrumId = scrum.ScrumId,
                    CreatedById = scrum.CreatedById,
                    CreationDateTime = scrum.CreationDateTime,
                    ResponsibleId = scrum.ResponsibleId,
                    DepartmentId = scrum.DepartmentId,
                    Action = scrum.Action,
                    ClassificationId = scrum.ClassificationId,
                    ScrumStatusId = scrum.ScrumStatusId,
                    DueDateTime = scrum.DueDateTime,
                    CompletionDateTime = scrum.CompletionDateTime,
                    Notes = scrum.Notes
                });
            }

            return PartialView("_CompletedPartialView", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("sender@outlook.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "user@outlook.com",  // replace with valid value
                        Password = "password"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
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
