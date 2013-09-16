using System.Collections.Generic;
using FluentValidation.Results;
using LayeredDev.DAL;
using LayeredDev.ExceptionHandler;

namespace LayeredDev.Responses
{
    public interface IResponse
    {
        IEnumerable<DALError> DALErrors { get; set; }
        IEnumerable<ValidationFailure> ValidationErrors { get; set; }
        bool WasSuccessful { get; set; }
        IHandledException Exception { get; set; }
    }
}