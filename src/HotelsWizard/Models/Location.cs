using System;
using System.Text;

namespace HotelsWizard.Models
{
    public class Location {

        public float lat;

        public float lon;

        public override string ToString() {
            return (new StringBuilder()).Append(lat).Append(",").Append(lon).ToString();
        }
    }
    
}