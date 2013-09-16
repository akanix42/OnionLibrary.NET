using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace LayeredDev.ExceptionHandler
{
    public class ExceptionHandler
    {
        public static IHandledException HandleException(Exception ex)
        {
            if (ex is DbUpdateException)
                return new HandledException() { Message = ex.InnerException.InnerException.ToString() };

            if (ex is DbEntityValidationException)
                return new HandledDbValidationException()
                {
                    Message = ex.Message,
                    Errors = ((DbEntityValidationException)ex).EntityValidationErrors.SelectMany(
                        e => e.ValidationErrors).ToList()
                };

            return new HandledException() { Message = ex.Message };
        }

    }
}
