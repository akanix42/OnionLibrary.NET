using System.Collections.Generic;
using FluentValidation.Results;
using LayeredDev.DAL;
using LayeredDev.ExceptionHandler;

namespace LayeredDev.Responses
{
    public class IdResponse : IResponse
    {
        public IHandledException Exception { get; set; }
        public IEnumerable<DALError> DALErrors { get; set; }
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
        public bool WasSuccessful { get; set; }
        public long Id { get; set; }

    }
}
