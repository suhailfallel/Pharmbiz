using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Configuration;
using DAL.Manager;
using DAL.Model;
using PharmBizz.Models;

namespace PharmBizz.Controllers
{
    public class CompanyController : Controller
    {
        CompanyRegistration compdb = new CompanyRegistration();
        MedicineList medlstdb = new MedicineList();
        OutletOrders outodrdb = new OutletOrders();
        // GET: Company
        public ActionResult Index(int id=0)
        {
            var compid = Session["Id"];
            if(compid == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            id = Convert.ToInt32(compid);
            Company comp = compdb.Companies.Find(id);
            ENT_CompanyRegistration eNT_Company = new ENT_CompanyRegistration();
            eNT_Company.Company_Name = comp.Company_Name;
            eNT_Company.Company_Address = comp.Company_Address;
            eNT_Company.Company_RegNo = comp.Company_RegNo;
            eNT_Company.Company_District = comp.Company_District;
            eNT_Company.Company_State = comp.Company_State;
            eNT_Company.Company_Contact = comp.Company_Contact;
            eNT_Company.Company_Email = comp.Company_Email;
            eNT_Company.Username = comp.Username;
            eNT_Company.Password = comp.Password;
            return View(eNT_Company);
        }

        public ActionResult CompanyUpdation(int id = 0)
        {
            var compid = Session["Id"];
            if (compid == null)
            {
                return RedirectToAction("Login","Home",null);
            }
            id = Convert.ToInt32(compid);
            ENT_CompanyRegistration eNT_Company = new ENT_CompanyRegistration();
            Company comp = compdb.Companies.Find(id);
            eNT_Company.Company_Name = comp.Company_Name;
            eNT_Company.Company_RegNo = comp.Company_RegNo;
            eNT_Company.Company_Address = comp.Company_Address;
            eNT_Company.Company_District = comp.Company_District;
            eNT_Company.Company_State = comp.Company_State;
            eNT_Company.Company_Contact = comp.Company_Contact;
            eNT_Company.Company_Email = comp.Company_Email;
            eNT_Company.Username = comp.Username;
            eNT_Company.Password = comp.Password;
            return View(eNT_Company);
        }

        [HttpPost]

        public ActionResult CompanyUpdation(ENT_CompanyRegistration compreg)
        {
            CompanyManager cmpmngr = new CompanyManager();
            ENT_CompanyRegistration eNT_Company = compreg;
            Company compobj = new Company();
            compobj.Id = Convert.ToInt32(Session["Id"]);
            if (compobj.Id == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            compobj.Company_Name = eNT_Company.Company_Name;
            compobj.Company_Address = eNT_Company.Company_Address;
            compobj.Company_RegNo = eNT_Company.Company_RegNo;
            compobj.Company_District = eNT_Company.Company_District;
            compobj.Company_State = eNT_Company.Company_State;
            compobj.Company_Contact = eNT_Company.Company_Contact;
            compobj.Company_Email = eNT_Company.Company_Email;
            compobj.Username = eNT_Company.Username;
            compobj.Password = eNT_Company.Password;
            var result = cmpmngr.CompanyUpdation(compobj);
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult AddMedicine()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddMedicine(ENT_AddMedicine addmed)
        {
            string FileName = Path.GetFileNameWithoutExtension(addmed.MedImage.FileName);
            string FileExtension = Path.GetExtension(addmed.MedImage.FileName);
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
            addmed.Medicine_Image = UploadPath + FileName;
            addmed.MedImage.SaveAs(addmed.Medicine_Image);
            CompanyManager cmpmngr = new CompanyManager();
            Medicine meds = new Medicine();
            meds.Batch_No = Convert.ToInt32(addmed.Batch_No);
            meds.Medicine_Name = addmed.Medicine_Name;
            meds.Dosage = addmed.Dosage;
            meds.Medicine_Image = "/UploadedImages/" + FileName;
            meds.Company_Id = Convert.ToInt32(Session["Id"]);//session
            if (meds.Company_Id == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            meds.Date_of_Mfg = Convert.ToDateTime(addmed.Date_of_Mfg);
            meds.Date_of_Exp = Convert.ToDateTime(addmed.Date_of_Exp);
            meds.Price = Convert.ToInt32(addmed.Price);
            meds.Quantity = Convert.ToInt32(addmed.Quantity);
            var result = cmpmngr.AddMedicine(meds);
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }
            else if(result=="Already Exist")
            {
                return RedirectToAction("AlreadyExist");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult AlreadyExist()
        {
            return View();
        }

        public ActionResult ViewAddedMeds()
        {
            int compId = Convert.ToInt32(Session["Id"]);
            if (compId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            var meds = medlstdb.Medicines.Where(e => e.Company_Id == compId).ToList();
            return View(meds);
        }

        public ActionResult UpdateMedicine(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine meds = medlstdb.Medicines.Find(id);
            if (meds == null)
            {
                return HttpNotFound();
            }
            return View(meds);
        }

        [HttpPost]

        public ActionResult UpdateMedicine(Medicine meds)
        {
            if (ModelState.IsValid)
            {
                medlstdb.Entry(meds).State = EntityState.Modified;
                medlstdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meds);
        }

        public ActionResult ViewOrders()
        {
            int compId = Convert.ToInt32(Session["Id"]);
            if (compId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(outodrdb.OutletOrder.Where(e=>e.Company_Id==compId && e.Order_Status!="Delivered").ToList());
        }

        public ActionResult Dispatched(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ordrobj = outodrdb.OutletOrder.Where(e => e.Id == id).SingleOrDefault();

            ordrobj.Order_Status = "Dispatched";
            outodrdb.Entry(ordrobj).State = EntityState.Modified;
            outodrdb.SaveChanges();
            var medstk = medlstdb.Medicines.Find(ordrobj.Medicine_Id);
            medstk.Quantity = medstk.Quantity - ordrobj.Quantity;
            medlstdb.Entry(medstk).State = EntityState.Modified;
            medlstdb.SaveChanges();
            return RedirectToAction("ViewOrders");
        }

        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ordrobj = outodrdb.OutletOrder.Where(e => e.Id == id).SingleOrDefault();
            ordrobj.Order_Status = "Canceled";
            outodrdb.Entry(ordrobj).State = EntityState.Modified;
            outodrdb.SaveChanges();
            return RedirectToAction("ViewOrders");
        }

        public ActionResult Delivered(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ordrobj = outodrdb.OutletOrder.Where(e => e.Id == id).SingleOrDefault();
            ordrobj.Order_Status = "Delivered";
            outodrdb.Entry(ordrobj).State = EntityState.Modified;
            outodrdb.SaveChanges();
            OutletStocks outltstkdb = new OutletStocks();
            var stkobj = outltstkdb.OutletStock.Where(e => e.Outlet_Name == ordrobj.Outlet_Name && e.Medicine_Name == ordrobj.Medicine_Name && e.Medicine_Dosage == ordrobj.Medicine_Dosage).SingleOrDefault();
            OutletStock outletstock = new OutletStock();
            if (stkobj == null)
            {
                outletstock.Outlet_Id = Convert.ToInt32(ordrobj.Outlet_Id);
                outletstock.Outlet_Name = ordrobj.Outlet_Name;
                outletstock.Medicine_Id = Convert.ToInt32(ordrobj.Medicine_Id);
                outletstock.Medicine_Name = ordrobj.Medicine_Name;
                outletstock.Medicine_Dosage = ordrobj.Medicine_Dosage;
                outletstock.Batch_No = ordrobj.Batch_No;
                outletstock.Mfg_Date = Convert.ToDateTime(ordrobj.Mfg_Date);
                outletstock.Exp_Date = Convert.ToDateTime(ordrobj.Exp_Date);
                outletstock.Quantity = Convert.ToInt32(ordrobj.Quantity);
                outletstock.Price = Convert.ToInt32(ordrobj.Price);
                outletstock.Company_Id = Convert.ToInt32(ordrobj.Company_Id);
                outletstock.Company_Name = ordrobj.Company_Name;
                outletstock.Stock_Status = "In-Stock";
                outltstkdb.OutletStock.Add(outletstock);
                outltstkdb.SaveChanges();
               
            }
            else
            {
                stkobj.Quantity = stkobj.Quantity + ordrobj.Quantity;
                stkobj.Stock_Status = "In-Stock";
                outltstkdb.Entry(stkobj).State = EntityState.Modified;
                outltstkdb.SaveChanges();
               
            }
            return RedirectToAction("ViewOrders");
        }

        public ActionResult ViewSales()
        {
            int compId = Convert.ToInt32(Session["Id"]);
            if (compId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(outodrdb.OutletOrder.Where(e => e.Order_Status == "Delivered").ToList());
        }
    }
}