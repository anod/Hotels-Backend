using System;

namespace HotelsWizard.Models.AccInfo
{
    public class Facility {
        public string Id;
        public string Name;
        public int Category;
        public FacilityData Data;

        public Facility(String id, String name, int category, FacilityData data) {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Data = data;
        }

        public class FacilityData {
            public bool Free;
            public int Location;

            public FacilityData(bool free, int location) {
                this.Free = free;
                this.Location = location;
            }

        }

    }
    
}