using System.Collections.Generic;

namespace HotelsWizard.Models.Response
{
    public class ErrorMeta : Meta
    {

        public int ErrorCode;

        public string ErrorMessage;
        
        public List<object> ErrorData;
        
        public ErrorMeta() : base() {
            
        }
        
        public ErrorMeta(int statusCode, int errorCode, string errorMessage) : base(statusCode) {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        
    }
}