using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Model;

namespace DAL.Manager
{
    public class OutletManager
    {
        OutletRegistration outdb = new OutletRegistration();
        MedicineList medsdb = new MedicineList();
        OutletOrders outodrdb = new OutletOrders();
        public string OutletUpdation(MedicalOutlet medout)
        {
            int result;

            var objout = outdb.MedicalOutlets.Where(e => e.Id == medout.Id && e.Status != "D").SingleOrDefault();
            if(objout == null)
            {
                result = 0;
            }
            else
            {
                objout.Outlet_Name = medout.Outlet_Name;
                objout.Outlet_LicensiName = medout.Outlet_LicensiName;
                objout.Outlet_LicenseNum = medout.Outlet_LicenseNum;
                objout.Outlet_Address = medout.Outlet_Address;
                objout.Outlet_Place = medout.Outlet_Place;
                objout.Outlet_District = medout.Outlet_District;
                objout.Outlet_State = medout.Outlet_State;
                objout.Outlet_Contact = medout.Outlet_Contact;
                objout.Outlet_Email = medout.Outlet_Email;
                objout.Username = medout.Username;
                objout.Password = medout.Password;
                objout.Status = "A";
                outdb.Entry(objout).State = EntityState.Modified;
                result = outdb.SaveChanges();
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

        public string PlaceOrder(OutletOrder outletOrders)
        {
            int result;

            var medobj = medsdb.Medicines.Where(e => e.Id == outletOrders.Medicine_Id && e.Stock_Status == "In-Stock").SingleOrDefault();
            var outletobj = outdb.MedicalOutlets.Where(e => e.Id == outletOrders.Outlet_Id && e.Status != "D").SingleOrDefault();

            outletOrders.Outlet_Name = outletobj.Outlet_Name;
            outletOrders.Outlet_Address = outletobj.Outlet_Address;
            outletOrders.Medicine_Name = medobj.Medicine_Name;
            outletOrders.Medicine_Dosage = medobj.Dosage;
            outletOrders.Batch_No = medobj.Batch_No.ToString();
            outletOrders.Mfg_Date = medobj.Date_of_Mfg;
            outletOrders.Exp_Date = medobj.Date_of_Exp;
            outletOrders.Price = medobj.Price;
            outletOrders.Company_Id = medobj.Company_Id;
            outletOrders.Company_Name = medobj.Company_Name;
            outletOrders.Order_Status = "Order Placed";
            outodrdb.OutletOrder.Add(outletOrders);
            result = outodrdb.SaveChanges();
            if (result > 0)
            {
                return "Success";
            }
            else
            {
                return "Error";
            }
        }

    }
}
