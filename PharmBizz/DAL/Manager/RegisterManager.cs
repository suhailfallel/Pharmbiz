using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using System.Data.Entity;

namespace DAL.Manager
{
    public class RegisterManager
    {
        UserRegistration userdb = new UserRegistration();
        public string UserRegistration(User usr)
        {
            int result;

            var objusr = userdb.Users.Where(e => e.Email == usr.Email && e.Status != "D").SingleOrDefault();
            if (objusr == null)
            {
                usr.Status = "A";
                userdb.Users.Add(usr);
                result = userdb.SaveChanges();
            }
            else
            {
                //objusr.Name = usr.Name;
                //objusr.Address = usr.Address;
                //objusr.LandMark = usr.LandMark;
                //objusr.District = usr.District;
                //objusr.State = usr.State;
                //objusr.Email = usr.Email;
                //objusr.Contact = usr.Contact;
                //objusr.Username = usr.Username;
                //objusr.Password = usr.Password;
                //objusr.Status = "A";
                //db.Entry(objusr).State = EntityState.Modified;
                //result = db.SaveChanges();
                result = 0;
            }
            if (result > 0)
            {
                return "Success";
            }
            else if(result == 0)
            {
                return "Already Exist";
            }
            else
            {
                return "Error";
            }
        }

        OutletRegistration outletdb = new OutletRegistration();

        public string OutletRegistration(MedicalOutlet medout)
        {
            int result;

            var objusr = outletdb.MedicalOutlets.Where(e => e.Outlet_Email == medout.Outlet_Email && e.Status != "D").SingleOrDefault();
            if(objusr == null)
            {
                medout.Status = "P";
                outletdb.MedicalOutlets.Add(medout);
                result = outletdb.SaveChanges();
            }
            else
            {
                result = 0;
            }
            if(result > 0)
            {
                return "Success";
            }
            else if(result == 0)
            {
                return "Already Exist";
            }
            else
            {
                return "Error";
            }
        }

        CompanyRegistration compdb = new CompanyRegistration();

        public string CompanyRegistration(Company company)
        {
            int result;

            var compobj = compdb.Companies.Where(e => e.Company_Email == company.Company_Email && e.Status != "D").SingleOrDefault();
            if(compobj == null)
            {
                company.Status = "P";
                compdb.Companies.Add(company);
                result = compdb.SaveChanges();
            }
            else
            {
                result = 0;
            }
            if (result > 0)
            {
                return "Success";
            }
            else if (result == 0)
            {
                return "Already Exist";
            }
            else
            {
                return "Error";
            }
        }
    }
}
