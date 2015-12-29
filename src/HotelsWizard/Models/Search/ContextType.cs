using System;
using System.Collections.Generic;

namespace HotelsWizard.Models.Search
{
    public abstract class ContextType
    {
        public const string SPR = "spr"; // Single point radius
        public const string POLYGON = "poly";
        public const string VIEWPORT = "viewport";
        public const string LIST = "list";
        public String Value { get; set; }

        protected ContextType(String type)
        {
            Value = type;
        }

        public abstract string GetContext();
    }

}