using System;

namespace HotelsWizard.Models.Response {
    
    class ResponseException : Exception {
        
        public ErrorResponse Error { get; private set; }
        
        public ResponseException(ErrorResponse error) : base(error.Meta.ErrorMessage) {
            Error = error;
        }
        
    }
    
}