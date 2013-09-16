using System.Collections.Generic;
using FluentValidation.Results;
using LayeredDev.DAL;
using LayeredDev.ExceptionHandler;
using Newtonsoft.Json;

namespace LayeredDev.Responses
{
    public class BasicResponse : IResponse
    {
        public IHandledException Exception { get; set; }
        public IEnumerable<DALError> DALErrors { get; set; }
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
        public bool WasSuccessful { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class BasicResponse<T> : BasicResponse
    {
        public T Object { get; set; }

    }

}
