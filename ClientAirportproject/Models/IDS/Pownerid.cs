using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models.IDS
{
    public class Pownerid
    {
        private static readonly object LockObject = new object();

        public static int GetNextPlaneOwnerID()
        {
            int currentID = GetCurrentPlaneID();
            IncrementPlaneID();
            return currentID;
        }

        private static int GetCurrentPlaneID()
        {
            return (int)(HttpContext.Current.Application["pOwnerID"] ?? 0);
        }

        private static void IncrementPlaneID()
        {
            lock (LockObject)
            {
                int currentValue = GetCurrentPlaneID();
                HttpContext.Current.Application["pOwnerID"] = currentValue + 1;
            }
        }
    }
}