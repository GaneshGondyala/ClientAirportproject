using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models.IDS
{
    public class ManagerIDs
    {
        private static readonly object LockObject = new object();

        public static int GetNextmanagerID()
        {
            int currentID = GetCurrentpilotID();
            IncrementPlaneID();
            return currentID;
        }

        private static int GetCurrentpilotID()
        {
            return (int)(HttpContext.Current.Application["MgrID"] ?? 0);
        }

        private static void IncrementPlaneID()
        {
            lock (LockObject)
            {
                int currentValue = GetCurrentpilotID();
                HttpContext.Current.Application["MgrID"] = currentValue + 1;
            }
        }
    }
}
