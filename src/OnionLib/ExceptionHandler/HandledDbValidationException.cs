using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace LayeredDev.ExceptionHandler
{
    public class HandledDbValidationException : IHandledException
    {
        public string Message { get; set; }
        public List<DbValidationError> Errors { get; set; }
    }
}