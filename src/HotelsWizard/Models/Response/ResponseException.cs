using System;

namespace HotelsWizard.Models.Response {
    
    [Serializable]
    class ResponseException : Exception {
        
        public ErrorResponse Error { get; private set; }
        
        public ResponseException(ErrorResponse error) : base(error.meta.ErrorMessage) {
            Error = error;
        }
        
    }
    
}