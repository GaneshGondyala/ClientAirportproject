using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Models.IDS
{
    public class PilotID
    {
        private static readonly object LockObject = new object();

        public static int GetNextPilotID()
        {
            int currentID = GetCurrentpilotID();
            IncrementPilotID();
            return currentID;
        }

        private static int GetCurrentpilotID()
        {
            return (int)(HttpContext.Current.Application["PilotID"] ?? 0);
        }

        private static void IncrementPilotID()
        {
            lock (LockObject)
            {
                int currentValue = GetCurrentpilotID();
                HttpContext.Current.Application["PilotID"] = currentValue + 1;
            }
        }
    }
}