using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HotelsWizard.Connector.Etb {
    public class RestContractResolver : CamelCasePropertyNamesContractResolver {

        protected override string ResolveDictionaryKey(string dictionaryKey) {
            return dictionaryKey;
        }
    }

}