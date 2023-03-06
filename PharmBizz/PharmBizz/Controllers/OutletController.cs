using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using DAL.Manager;
using DAL.Model;
using PharmBizz.Models;

namespace PharmBizz.Controllers
{
    public class OutletController : Controller
    {
        OutletRegistration outdb = new OutletRegistration();
        MedicineList meddb = new MedicineList();
        OutletOrders outodrdb = new OutletOrders();
        OutletStocks outstkdb = new OutletStocks();
        UsersOrder usrodrdb = new UsersOrder();

        // GET: Outlet
        public ActionResult Index(int id=0)
        {
            var outletid = Session["Id"];//session
            if(outletid == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            id = Convert.ToInt32(outletid);
            MedicalOutlet medtbl = outdb.MedicalOutlets.Find(id);
            ENT_OutletRegistration eNT_Outlet = new ENT_OutletRegistration();
            eNT_Outlet.Outlet_Name = medtbl.Outlet_Name;
            eNT_Outlet.Outlet_LicensiName = medtbl.Outlet_LicensiName;
            eNT_Outlet.Outlet_LicenseNum = medtbl.Outlet_LicenseNum;
            eNT_Outlet.Outlet_Address = medtbl.Outlet_Address;
            eNT_Outlet.Outlet_Place = medtbl.Outlet_Place;
            eNT_Outlet.Outlet_District = medtbl.Outlet_District;
            eNT_Outlet.Outlet_State = medtbl.Outlet_State;
            eNT_Outlet.Outlet_Contact = medtbl.Outlet_Contact;
            eNT_Outlet.Outlet_Email = medtbl.Outlet_Email;
            eNT_Outlet.Username = medtbl.Username;
            eNT_Outlet.Password = medtbl.Password;
            return View(eNT_Outlet);
        }

        public ActionResult OutletUpdation(int id = 0)
        {
            var outletid = Session["Id"];
            if(outletid == null)
            {
                return RedirectToAction("Login","Home",null);
            }
            id = Convert.ToInt32(outletid);
            ENT_OutletRegistration eNT_Outlet = new ENT_OutletRegistration();
            var medout = outdb.MedicalOutlets.Find(id);
            eNT_Outlet.Outlet_Name = medout.Outlet_Name;
            eNT_Outlet.Outlet_LicensiName = medout.Outlet_LicensiName;
            eNT_Outlet.Outlet_LicenseNum = medout.Outlet_LicenseNum;
            eNT_Outlet.Outlet_Address = medout.Outlet_Address;
            eNT_Outlet.Outlet_Place = medout.Outlet_Place;
            eNT_Outlet.Outlet_District = medout.Outlet_District;
            eNT_Outlet.Outlet_State = medout.Outlet_State;
            eNT_Outlet.Outlet_Contact = medout.Outlet_Contact;
            eNT_Outlet.Outlet_Email = medout.Outlet_Email;
            eNT_Outlet.Username = medout.Username;
            eNT_Outlet.Password = medout.Password;
            return View(eNT_Outlet);
        }

        [HttpPost]

        public ActionResult OutletUpdation(ENT_OutletRegistration outreg)
        {
            OutletManager outmngr = new OutletManager();
            ENT_OutletRegistration outletreg = outreg;
            MedicalOutlet medout = new MedicalOutlet();
            medout.Id = Convert.ToInt32(Session["Id"]);//session
            if (medout.Id == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            medout.Outlet_Name = outletreg.Outlet_Name;
            medout.Outlet_LicensiName = outletreg.Outlet_LicensiName;
            medout.Outlet_LicenseNum = outletreg.Outlet_LicenseNum;
            medout.Outlet_Address = outletreg.Outlet_Address;
            medout.Outlet_Place = outletreg.Outlet_Place;
            medout.Outlet_District = outletreg.Outlet_District;
            medout.Outlet_State = outletreg.Outlet_State;
            medout.Outlet_Contact = outletreg.Outlet_Contact;
            medout.Outlet_Email = outletreg.Outlet_Email;
            medout.Username = outletreg.Username;
            medout.Password = outletreg.Password;
            var result = outmngr.OutletUpdation(medout);
            if(result == "Success")
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

        public ActionResult SearchMedicines()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SearchMedicines(ENT_Search search)
        {
            //var medname = search.Medicine_Name;
            TempData["medname"] = search.Medicine_Name;
            return RedirectToAction("ViewMeds","Outlet");
        }

        public ActionResult ViewMeds()
        {
            var medname = TempData["medname"];
            var meds = meddb.Medicines.Where(e => e.Medicine_Name == medname).ToList();
            return View(meds);
        }

        public ActionResult PlaceOrder(int? id, ENT_OutletOrder outletOrder)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine meds = meddb.Medicines.Find(id);
            meds.Quantity = outletOrder.Quantity;
            if(meds == null)
            {
                return HttpNotFound();
            }
            return View(meds);
        }

        [HttpPost]

        public ActionResult PlaceOrder(int id, Medicine meds)
        {
            OutletManager outmngr = new OutletManager();
            //Medicine meds = meddb.Medicines.Find(id);
            OutletOrder outletOrder = new OutletOrder();
            outletOrder.Outlet_Id = Convert.ToInt32(Session["Id"]);//session
            if (outletOrder.Outlet_Id == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            outletOrder.Medicine_Id = id;
            outletOrder.Quantity = meds.Quantity;
            var result = outmngr.PlaceOrder(outletOrder);
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult ViewPurchases()
        {
            int outId = Convert.ToInt32(Session["Id"]);//session
            if (outId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(outodrdb.OutletOrder.Where(e => e.Outlet_Id == outId).ToList());
        }

        public ActionResult ViewStock()
        {
            int outId = Convert.ToInt32(Session["Id"]);
            if (outId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(outstkdb.OutletStock.Where(e => e.Outlet_Id == outId).ToList());
        }

        public ActionResult ViewUserOrders()
        {
            int outletId = Convert.ToInt32(Session["Id"]);//session
            if (outletId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(usrodrdb.UserOrders.Where(e => e.Outlet_Id == outletId && (e.OrderStatus == "Ordered" || e.OrderStatus == "Dispatched")).ToList());
        }

        public ActionResult Dispatched(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var objodr = usrodrdb.UserOrders.Find(id);

            objodr.OrderStatus = "Dispatched";
            usrodrdb.Entry(objodr).State = EntityState.Modified;
            usrodrdb.SaveChanges();
            var outstlobj = outstkdb.OutletStock.Where(e => e.Outlet_Id == objodr.Outlet_Id && e.Medicine_Id == objodr.Medicine_Id).SingleOrDefault();
            outstlobj.Quantity = outstlobj.Quantity - objodr.Quantity;
            outstkdb.Entry(outstlobj).State = EntityState.Modified;
            outstkdb.SaveChanges();
            return RedirectToAction("ViewUserOrders");
        }

        public ActionResult Delivered(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var odrobj = usrodrdb.UserOrders.Find(id);

            odrobj.OrderStatus = "Delivered";
            usrodrdb.Entry(odrobj).State = EntityState.Modified;
            usrodrdb.SaveChanges();
            return RedirectToAction("ViewUserOrders");
        }

        public ActionResult ViewSales()
        {
            var outletId = Convert.ToInt32(Session["Id"]);//session
            if (outletId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(usrodrdb.UserOrders.Where(e => e.Outlet_Id == outletId && e.OrderStatus == "Delivered").ToList());
        }
    }
}