using System.Collections.Generic;
using HotelsWizard.Models.AccInfo;

namespace HotelsWizard.Models.Response
{
    public class SearchResponse : ApiResponse
    {

        public SearchMeta Meta;

        public List<Accommodation> Accommodations = new List<Accommodation>();
    }

}