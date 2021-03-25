using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class UserBLL
    {

        DBContextIns dBContext = DBContextIns.getIns();
        private static UserBLL Ins;

        private UserBLL()
        {

        }

        public static UserBLL getIns()
        {
            if (Ins== null)
            {
                Ins = new UserBLL();           
            }
            return Ins;
        }
        

        public string Add(User _user)
        {
            // handle
            dBContext.Add(_user);
            dBContext.SaveChanges();
            // return the status of handle: success or failed or...
            return null;
        }

        public string Remove(long _id)
        {
            // handle
            DbSet<User> users = dBContext.User;
            bool isDeleted = false;
            foreach (User user in users)
            {
                if (user.Id == _id)
                {
                    dBContext.User.Remove(user);
                    dBContext.SaveChanges();
                    isDeleted = true;
                    break;
                }
            }

            // return the status of handle: success or failed or...
            return isDeleted ?"Remove successfull": "Remove failed";
        }

        public string Update(User _user)
        {
            DbSet<User> users = dBContext.User;
            bool isUpdated = false;
            foreach (User user in users)
            {
                if (user.Username == _user.Username)
                {
                    user.Name = _user.Name;
                    dBContext.User.Update(user);
                    isUpdated = true;
                    break;
                }
            }

            dBContext.SaveChanges();

            // return the status of handle: success or failed or...
            return isUpdated ? "Update successfull" : "Update failed";
        }

        public string Get(long _id)
        {

            // return the status of handle: success or failed or...
            return null;
        }

        public DbSet<User> GetAll()
        {
            DbSet<User> users = dBContext.User;
            // return data
            return users;
        }
    }
}
