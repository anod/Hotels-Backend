using System.Collections.Generic;
using HotelsWizard.Models.AccInfo;

namespace HotelsWizard.Models.Response
{
    public class SearchResponse
    {

        public Meta meta;

        public List<Accommodation> accommodations = new List<Accommodation>();
    }

}