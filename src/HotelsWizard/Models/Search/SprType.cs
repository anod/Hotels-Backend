using System;
using System.Collections.Generic;

namespace HotelsWizard.Models.Search
{
    public class SprType : ContextType
    {
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }

        public double Radius { get; set; }

        public SprType() : base(SPR)
        {
            Radius = 5.0f;
        }

        public SprType(double latitude, double longitude) : this(latitude, longitude, 5.0f)
        {

        }

        public SprType(double latitude, double longitude, double radius) : this()
        {
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }

        public override string GetContext()
        {
            return Latitude + "," + Longitude + ";" + Radius;
        }

        public void setLatLng(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

}