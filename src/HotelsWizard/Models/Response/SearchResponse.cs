using System.Collections.Generic;
using HotelsWizard.Models.AccInfo;

namespace HotelsWizard.Models.Response
{
    public class SearchResponse
    {

        public Meta Meta;

        public List<Accommodation> Accommodations = new List<Accommodation>();
    }

}