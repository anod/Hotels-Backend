using HotelsWizard.Models;
using HotelsWizard.Models.Request;

using System;
using System.Text;
using System.Collections.Generic;

namespace HotelsWizard.Connector.Etb.Utils
{
    /**
     * @author alex
     * @date 2015-05-26
     */
    public class RequestUtils
    {

        public static void apply(HotelRequest request, DateRange dateRange, int persons, int rooms)
        {
            request.DateRange = dateRange;
            request.NumberOfPersons = persons;
            request.NumberOfRooms = rooms;
        }

        public static string capacity(int persons, int rooms)
        {
            if (persons == 0 || rooms == 0)
            {
                return "";
            }
            var capacities = new List<int>();
            for (int i = 1; i <= rooms; i++)
            {
                capacities.Add(persons);
            }
            return list(capacities);
        }

        public static string list(List<int> list)
        {
            if (list == null)
            {
                return "";
            }

            return String.Join(",", list);
        }

        public static String list(Dictionary<int, bool> list)
        {
            if (list == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            bool firstTime = true;
            foreach (int key in list.Keys)
            {
                // get the object by the key.
                bool v = list[key];
                if (!v)
                {
                    continue;
                }
                if (firstTime)
                {
                    firstTime = false;
                }
                else
                {
                    sb.Append(",");
                }
                sb.Append(key);
            }
            return sb.ToString();
        }

    }

}