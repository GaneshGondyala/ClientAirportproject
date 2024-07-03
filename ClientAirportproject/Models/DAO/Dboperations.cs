using ClientAirportproject.Models.BAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models.DAO
{
    
        public class Dboperations
        {
       
            public String checkingmanager(Metadata u)
            {

                var res = (from l1 in ClientAirportproject.Usrs
                           where l1.Username.Equals(u.Username)
     && l1.Password == u.Password
                           select l1).FirstOrDefault();
                if (res == null)
                {
                    return null;
                }
                else
                {
                    return res.Usertype;
                }

            }
        }
    
}