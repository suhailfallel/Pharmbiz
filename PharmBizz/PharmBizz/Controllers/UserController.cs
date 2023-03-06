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
    public class UserController : Controller
    {
        UserRegistration udb = new UserRegistration();
        OutletStocks outstkdb = new OutletStocks();
        UsersOrder usrodrdb = new UsersOrder();
        // GET: User
        public ActionResult Index(int id=0)
        {
            var userid = Session["Id"];
            if(userid == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            id = Convert.ToInt32(userid);
            User usrtbl = udb.Users.Find(id);
            ENT_UserRegistration eNT_User = new ENT_UserRegistration();
            eNT_User.Name = usrtbl.Name;
            eNT_User.Address = usrtbl.Address;
            eNT_User.LandMark = usrtbl.LandMark;
            eNT_User.District = usrtbl.District;
            eNT_User.State = usrtbl.State;
            eNT_User.Email = usrtbl.Email;
            eNT_User.Contact = usrtbl.Contact;
            eNT_User.Username = usrtbl.Username;
            eNT_User.Password = usrtbl.Password;
            return View(eNT_User);
        }

        public ActionResult UserUpdation(int id=0)
        {
            var userid = Session["Id"];//session
            if(userid == null)
            {
                return RedirectToAction("Login","Home",null);
            }
            id = Convert.ToInt32(userid);
            User usr = udb.Users.Find(id);
            ENT_UserRegistration eNT_User = new ENT_UserRegistration();
            eNT_User.Name = usr.Name;
            eNT_User.Address = usr.Address;
            eNT_User.LandMark = usr.LandMark;
            eNT_User.District = usr.District;
            eNT_User.State = usr.State;
            eNT_User.Email = usr.Email;
            eNT_User.Contact = usr.Contact;
            eNT_User.Username = usr.Username;
            eNT_User.Password = usr.Password;
            return View(eNT_User);
        }

        [HttpPost]

        public ActionResult UserUpdation(ENT_UserRegistration usrreg)
        {
            UserManager usrmngr = new UserManager();
            ENT_UserRegistration usrregobj = usrreg;
            User usrobj = new User();
            usrobj.Id = Convert.ToInt32(Session["Id"]);
            if (usrobj.Id==null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            usrobj.Name = usrregobj.Name;
            usrobj.Address = usrregobj.Address;
            usrobj.LandMark = usrregobj.LandMark;
            usrobj.District = usrregobj.District;
            usrobj.State = usrregobj.State;
            usrobj.Email = usrregobj.Email;
            usrobj.Contact = usrregobj.Contact;
            usrobj.Username = usrregobj.Username;
            usrobj.Password = usrregobj.Password;
            var result = usrmngr.UserUpdation(usrobj);
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }
            else if (result == "Doesnot Exist")
            {
                return RedirectToAction("DoesnotExist");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult DoesnotExist()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult SearchMedicine()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SearchMedicine(ENT_Search search)
        {
            TempData["medname"] = search.Medicine_Name;
            return RedirectToAction("ViewMeds", "User");
        }

        public ActionResult ViewMeds()
        {
            var medname = TempData["medname"];
            var meds=outstkdb.OutletStock.Where(e=>e.Medicine_Name==medname).ToList();
            return View(meds);
        }

        public ActionResult PlaceOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutletStock outletStock = outstkdb.OutletStock.Find(id);
            if (outletStock == null)
            {
                return HttpNotFound();
            }
            return View(outletStock);
        }


        [HttpPost]

        public ActionResult PlaceOrder(int id, OutletStock outletStock)
        {
            UserManager usrmngr = new UserManager();
            UserOrder userOrder = new UserOrder();
            var outstock = outstkdb.OutletStock.Find(outletStock.Outlet_Id);
            userOrder.User_Id = Convert.ToInt32(Session["Id"]);//session
            if (userOrder.User_Id == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            userOrder.Medicine_Id = id;
            userOrder.Outlet_Id = outletStock.Outlet_Id;
            userOrder.Outlet_Name = outstock.Outlet_Name;
            userOrder.Medicine_Name = outstock.Medicine_Name;
            userOrder.Medicine_Dosage = outstock.Medicine_Dosage;
            userOrder.Company_Name = outstock.Company_Name;
            userOrder.BatchNo = Convert.ToInt32(outstock.Batch_No);
            userOrder.Quantity = outletStock.Quantity;
            userOrder.Price = outstock.Price;
            userOrder.TotalPrice = outletStock.Quantity * outstock.Price;
            var result = usrmngr.PlaceOrder(userOrder);
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult ViewCart()
        {
            int userId = Convert.ToInt32(Session["Id"]);//session
            if (userId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(usrodrdb.UserOrders.Where(e => e.User_Id == userId && e.OrderStatus != "Delivered").ToList());
        }

        public ActionResult ViewPurchases()
        {
            int userId = Convert.ToInt32(Session["Id"]);//session
            if (userId == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            return View(usrodrdb.UserOrders.Where(e => e.User_Id == userId && e.OrderStatus == "Delivered").ToList());
        }

        public ActionResult CancelOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userOrder = usrodrdb.UserOrders.Where(e => e.Id == id).SingleOrDefault();
            userOrder.OrderStatus = "Canceled";
            usrodrdb.Entry(userOrder).State = EntityState.Modified;
            usrodrdb.SaveChanges();
            return RedirectToAction("ViewCart");
        }
    }
}