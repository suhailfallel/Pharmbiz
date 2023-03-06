using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Model;
using DAL.Manager;
using PharmBizz.Models;
using System.Web.Security;

namespace PharmBizz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistration(ENT_UserRegistration userreg)
        {
            RegisterManager rgmngr = new RegisterManager();
            ENT_UserRegistration objusrrg = userreg;
            User objsuser = new User();
            objsuser.Name = objusrrg.Name;
            objsuser.Address = objusrrg.Address;
            objsuser.LandMark = objusrrg.LandMark;
            objsuser.District = objusrrg.District;
            objsuser.State = objusrrg.State;
            objsuser.Email = objusrrg.Email;
            objsuser.Contact = objusrrg.Contact;
            objsuser.Username = objusrrg.Username;
            objsuser.Password = objusrrg.Password;
            var result = rgmngr.UserRegistration(objsuser);
            if(result == "Success")
            {
                return RedirectToAction("Index");
            }
            else if(result == "Already Exist")
            {
                return RedirectToAction("AlreadyExist");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult OutletRegistration()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult OutletRegistration(ENT_OutletRegistration outltreg)
        {
            RegisterManager rgmngr = new RegisterManager();
            ENT_OutletRegistration outletobj = outltreg;
            MedicalOutlet medoutobj = new MedicalOutlet();
            medoutobj.Outlet_Name = outletobj.Outlet_Name;
            medoutobj.Outlet_LicensiName = outletobj.Outlet_LicensiName;
            medoutobj.Outlet_LicenseNum = outletobj.Outlet_LicenseNum;
            medoutobj.Outlet_Address = outletobj.Outlet_Address;
            medoutobj.Outlet_Place = outletobj.Outlet_Place;
            medoutobj.Outlet_District = outletobj.Outlet_District;
            medoutobj.Outlet_State = outletobj.Outlet_State;
            medoutobj.Outlet_Contact = outletobj.Outlet_Contact;
            medoutobj.Outlet_Email = outletobj.Outlet_Email;
            medoutobj.Username = outletobj.Username;
            medoutobj.Password = outletobj.Password;
            var result = rgmngr.OutletRegistration(medoutobj);
            if(result == "Success")
            {
                return RedirectToAction("Index");
            }
            else if(result =="Already Exist")
            {
                return RedirectToAction("AlreadyExist");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult CompanyRegistration()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CompanyRegistration(ENT_CompanyRegistration compreg)
        {
            RegisterManager rgmngr = new RegisterManager();
            ENT_CompanyRegistration eNT_Company = compreg;
            Company company = new Company();
            company.Company_Name = eNT_Company.Company_Name;
            company.Company_RegNo = eNT_Company.Company_RegNo;
            company.Company_Address = eNT_Company.Company_Address;
            company.Company_District = eNT_Company.Company_District;
            company.Company_State = eNT_Company.Company_State;
            company.Company_Contact = eNT_Company.Company_Contact;
            company.Company_Email = eNT_Company.Company_Email;
            company.Username = eNT_Company.Username;
            company.Password = eNT_Company.Password;
            var result = rgmngr.CompanyRegistration(company);
            if(result == "Success")
            {
                return RedirectToAction("Index");
            }
            else if(result == "Already Exist")
            {
                return RedirectToAction("AlreadyExist");
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

        public ActionResult AlreadyExist()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(ENT_Login login)
        {
            if (ModelState.IsValid)
            {
                Login logdb = new Login();
                var loginObj = logdb.LoginCredentials.Where(e => e.Username == login.Username && e.Password == login.Password && e.Status=="A").SingleOrDefault();

                if (loginObj == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    string role = loginObj.Role;

                    if (role == "User")
                    {
                        Session.Add("Id", loginObj.Reg_Id);
                        return RedirectToAction("Index", "User", new { id = loginObj.Reg_Id });
                    }
                    else if (role == "Outlet")
                    {
                        Session.Add("Id", loginObj.Reg_Id);
                        return RedirectToAction("Index", "Outlet", new { id = loginObj.Reg_Id });
                    }
                    else if (role == "Company")
                    {
                        Session.Add("Id", loginObj.Reg_Id);
                        return RedirectToAction("Index", "Company", new { id = loginObj.Reg_Id });
                    }
                    else if (role == "Admin")
                    {
                        Session.Add("Id", loginObj.Reg_Id);
                        return RedirectToAction("Details", "Admin", new { id = loginObj.Reg_Id });
                    }
                }
            }
            return RedirectToAction("Error");
        }

        public ActionResult Logout()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            

            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Home", null);
        }
    }
}