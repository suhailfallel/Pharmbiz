using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using System.Data;
using DAL.Manager;
using DAL.Model;
using PharmBizz.Models;

namespace PharmBizz.Controllers
{
    public class AdminController : Controller
    {
        Login logdb = new Login();
        OutletRegistration outdb = new OutletRegistration();
        UserRegistration udb = new UserRegistration();
        CompanyRegistration compdb = new CompanyRegistration();
        MedicineList meddb = new MedicineList();
        // GET: Admin
        public ActionResult Index()
        {
            return View(logdb.LoginCredentials.Where(e=>e.Role=="Admin").ToList());
        }

        public ActionResult Details(int? id)
        {
            id = Convert.ToInt32(Session["Id"]);
            if (id == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            LoginCredential login = logdb.LoginCredentials.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(LoginCredential login)
        {
            if (ModelState.IsValid)
            {
                login.Role = "Admin";
                login.Status = "A";
                logdb.LoginCredentials.Add(login);
                logdb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginCredential login = logdb.LoginCredentials.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        [HttpPost]

        public ActionResult Edit(LoginCredential login)
        {
            if (ModelState.IsValid)
            {
                logdb.Entry(login).State = EntityState.Modified;
                logdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginCredential login = logdb.LoginCredentials.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            LoginCredential login = logdb.LoginCredentials.Find(id);
            logdb.LoginCredentials.Remove(login);
            logdb.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AllOutlets()
        {
            return View(outdb.MedicalOutlets.ToList());
        }

        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOutlet medout = outdb.MedicalOutlets.Find(id);
            if(medout == null)
            {
                return HttpNotFound();
            }
            return View(medout);
        }

        [HttpPost]

        public ActionResult Accept(int id)
        {
            MedicalOutlet medout = outdb.MedicalOutlets.Find(id);
            medout.Status = "A";
            outdb.Entry(medout).State = EntityState.Modified;
            outdb.SaveChanges();
            return RedirectToAction("AllOutlets");
        }

        public ActionResult Reject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOutlet medout = outdb.MedicalOutlets.Find(id);
            if (medout == null)
            {
                return HttpNotFound();
            }
            return View(medout);
        }

        [HttpPost]

        public ActionResult Reject(int id)
        {
            MedicalOutlet medout = outdb.MedicalOutlets.Find(id);
            medout.Status = "D";
            outdb.Entry(medout).State = EntityState.Modified;
            outdb.SaveChanges();
            return View(medout);
        }

        public ActionResult AllUsers()
        {
            return View(udb.Users.ToList());
        }

        public ActionResult AllCompanies()
        {
            return View(compdb.Companies.ToList());
        }

        public ActionResult AcceptCompany(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = compdb.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        [HttpPost]

        public ActionResult AcceptCompany(int id)
        {
            Company company = compdb.Companies.Find(id);
            company.Status = "A";
            compdb.Entry(company).State = EntityState.Modified;
            compdb.SaveChanges();
            return RedirectToAction("AllCompanies");
        }

        public ActionResult RejectCompanies(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = compdb.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound(); 
            }
            return View(company);
        }

        [HttpPost]

        public ActionResult RejectCompanies(int id)
        {
            Company company = compdb.Companies.Find(id);
            company.Status = "R";
            compdb.Entry(company).State = EntityState.Modified;
            compdb.SaveChanges();
            return RedirectToAction("AllCompanies");
        }

        public ActionResult ViewMedicines()
        {
            return View(meddb.Medicines.ToList());
        }
    }
}