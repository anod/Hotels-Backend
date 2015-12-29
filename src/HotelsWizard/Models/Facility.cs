using System;

namespace HotelsWizard.Models
{
    public class Facility {
        public string id;
        public string name;
        public int category;
        public Data data;

        public Facility(String id, String name, int category, Data data) {
            this.id = id;
            this.name = name;
            this.category = category;
            this.data = data;
        }

        public class Data {
            public bool free;
            public int location;

            public Data(bool free, int location) {
                this.free = free;
                this.location = location;
            }

        }

    }
    
}