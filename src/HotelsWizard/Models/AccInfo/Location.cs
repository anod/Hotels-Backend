using System.Text;

namespace HotelsWizard.Models.AccInfo
{
    public class Location {

        public float Lat;

        public float Lon;

        public override string ToString() {
            return (new StringBuilder()).Append(Lat).Append(",").Append(Lon).ToString();
        }
    }
    
}