using System;
using System.Collections.Generic;

namespace HotelsWizard.Models.Search
{
    /**
     * @author user
     * @date 2015-10-08
     */
    public class ViewPortType : ContextType
    {
        protected double NortheastLat { get; set; }
        protected double NortheastLon { get; set; }
        protected double SouthwestLat { get; set; }
        protected double SouthwestLon { get; set; }

        public ViewPortType() : base(VIEWPORT)
        {

        }

        public ViewPortType(double northeastLat, double northeastLon, double southwestLat, double southwestLon) : base(VIEWPORT)
        {
            NortheastLat = northeastLat;
            NortheastLon = northeastLon;
            SouthwestLat = southwestLat;
            SouthwestLon = southwestLon;
        }

        public override string GetContext()
        {
            return NortheastLat + "," + NortheastLon + ";" + SouthwestLat + "," + SouthwestLon;
        }
    }

}
