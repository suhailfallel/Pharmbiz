using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Model;

namespace DAL.Manager
{
    public class UserManager
    {
        UserRegistration udb = new UserRegistration();
        UsersOrder usrodrdb = new UsersOrder();
        public string UserUpdation(User usr)
        {
            int result;

            var objusr = udb.Users.Where(e => e.Id == usr.Id && e.Status != "B").SingleOrDefault();
            if(objusr == null)
            {
                result = 0;
            }
            else
            {
                objusr.Name = usr.Name;
                objusr.Address = usr.Address;
                objusr.LandMark = usr.LandMark;
                objusr.District = usr.District;
                objusr.State = usr.State;
                objusr.Email = usr.Email;
                objusr.Contact = usr.Contact;
                objusr.Username = usr.Username;
                objusr.Password = usr.Password;
                objusr.Status = "A";
                udb.Entry(objusr).State = EntityState.Modified;
                result = udb.SaveChanges();
            }
            if (result > 0)
            {
                return "Success";
            }
            else if(result == 0)
            {
                return "Doesnot Exist";
            }
            else
            {
                return "Error";
            }
        }

        public string PlaceOrder(UserOrder userOrder)
        {
            int result;

            var usrobj = udb.Users.Find(userOrder.User_Id);
            
            userOrder.Name = usrobj.Name;
            userOrder.Address = usrobj.Address;
            userOrder.District = usrobj.District;
            userOrder.State = usrobj.State;
            userOrder.Contact = usrobj.Contact;
            userOrder.OrderStatus = "Ordered";
            usrodrdb.UserOrders.Add(userOrder);
            result = usrodrdb.SaveChanges();
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
