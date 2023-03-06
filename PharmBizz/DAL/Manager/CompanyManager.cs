using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using System.Data.Entity;

namespace DAL.Manager
{
    public class CompanyManager
    {
        CompanyRegistration compdb = new CompanyRegistration();
        MedicineList medlstdb = new MedicineList();

        public string CompanyUpdation(Company company)
        {
            int result;

            var compobj = compdb.Companies.Where(e => e.Id == company.Id && company.Status != "D").SingleOrDefault();
            if (compobj == null)
            {
                result = 0;
            }
            else
            {
                compobj.Company_Name = company.Company_Name;
                compobj.Company_RegNo = company.Company_RegNo;
                compobj.Company_Address = company.Company_Address;
                compobj.Company_District = company.Company_District;
                compobj.Company_State = company.Company_State;
                compobj.Company_Contact = company.Company_Contact;
                compobj.Company_Email = company.Company_Email;
                compobj.Username = company.Username;
                compobj.Password = company.Password;
                compobj.Status = "A";
                compdb.Entry(compobj).State = EntityState.Modified;
                result = compdb.SaveChanges();
            }
            if (result > 0)
            {
                return "Success";
            }
            else
            {
                return "Error";
            }
        }

        public string AddMedicine(Medicine meds)
        {
            int result;
            var cmpobj = compdb.Companies.Where(e => e.Id == meds.Company_Id && e.Status != "D").SingleOrDefault();
            var medobj = medlstdb.Medicines.Where(e => e.Id == meds.Id && e.Stock_Status == "In-Stock").SingleOrDefault();
            if (medobj == null)
            {
                meds.Company_Name = cmpobj.Company_Name;
                meds.Stock_Status = "In-Stock";
                medlstdb.Medicines.Add(meds);
                result = medlstdb.SaveChanges();
            }
            else
            {
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
    }
}
