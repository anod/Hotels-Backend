using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelsWizard.Connector.Rest
{
    public class JsonContent : HttpContent {
        public object Value { get; private set; }

        public JsonContent(object value) {
            Value = value;
            Headers.ContentType = new MediaTypeWithQualityHeaderValue(RestClient.MimeJson);
        }

        protected override bool TryComputeLength(out long length) {
            //we don't know. can't be computed up-front
            length = -1;
            return false;
        }

        protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context) {
            await Task.Run((Action)(() => {
                using (StreamWriter writer = new StreamWriter(stream))
                using (JsonTextWriter jsonWriter = new JsonTextWriter(writer)) {
                    JsonSerializer ser = new JsonSerializer();
                    ser.Serialize(jsonWriter, (object)this.Value);
                }
           }));
        }
    }
}
