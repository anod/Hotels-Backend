using System;
using System.Collections.Generic;

namespace HotelsWizard.Models.Search
{
    /**
     * @author alex
     * @date 2015-12-03
     */
    public class Filter
    {
        public Dictionary<int, bool> Stars { get; set; }
        public Dictionary<int, bool> Rating { get; set; }
        public Dictionary<int, bool> AccTypes { get; set; }
        public Dictionary<int, bool> MainFacilities { get; set; }

        public int MinRate { get; set; }
        public int MaxRate { get; set; }

        public Filter()
        {
        }

        public void AddMainFacility(int facility)
        {
            if (MainFacilities == null)
            {
                MainFacilities = new Dictionary<int, bool>();
            }
            MainFacilities.Add(facility, true);
        }

        public void AddAccType(int accType)
        {
            if (AccTypes == null)
            {
                AccTypes = new Dictionary<int, bool>();
            }
            AccTypes.Add(accType, true);
        }

        public void RemoveAccType(int accType)
        {
            if (AccTypes == null)
            {
                return;
            }
            AccTypes.Remove(accType);
        }

        public void RemoveMainFacility(int facility)
        {
            if (MainFacilities == null)
            {
                return;
            }
            MainFacilities.Remove(facility);
        }

        public bool IsEmpty()
        {
            return Stars == null &&
                   Rating == null &&
                   AccTypes == null &&
                   MainFacilities == null &&
                   MinRate == 0 &&
                   MaxRate == 0;
        }

    }
}