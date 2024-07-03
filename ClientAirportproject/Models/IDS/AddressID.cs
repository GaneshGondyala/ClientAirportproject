using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models.IDS
{
    public class AddressID
    {
        private static readonly object LockObject = new object();

        public static int GetNextAdresID()
        {
            int currentID = GetCurrentPlaneID();
            IncrementPlaneID();
            return currentID;
        }

        private static int GetCurrentPlaneID()
        {
            return (int)(HttpContext.Current.Application["AddressID"] ?? 0);
        }

        private static void IncrementPlaneID()
        {
            lock (LockObject)
            {
                int currentValue = GetCurrentPlaneID();
                HttpContext.Current.Application["AddressID"] = currentValue + 1;
            }
        }
    }
}