using System;
using HotelsWizard.Models.Response;

namespace HotelsWizard.Connector.Rest {
    
    class RestException : Exception {
        
        public ErrorResponse Error { get; private set; }
        
        public RestException(ErrorResponse error) : base(error.Meta.ErrorMessage) {
            Error = error;
        }
        
    }
    
}