using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAirportproject.Controllers
{
    public class PlaneID
    {
         private static readonly object LockObject = new object();

    public static int GetNextPlaneID()
    {
        int currentID = GetCurrentPlaneID();
        IncrementPlaneID();
        return currentID;
    }

    private static int GetCurrentPlaneID()
    {
        return (int)(HttpContext.Current.Application["PlaneID"] ?? 0);
    }

    private static void IncrementPlaneID()
    {
        lock (LockObject)
        {
            int currentValue = GetCurrentPlaneID();
            HttpContext.Current.Application["PlaneID"] = currentValue + 1;
        }
    }
    }
}