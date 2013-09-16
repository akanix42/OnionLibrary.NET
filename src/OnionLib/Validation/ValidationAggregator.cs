using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace LayeredDev.Validation
{
    public class ValidationAggregator
    {
        # region Properties and Fields
        
        public IEnumerable<ValidationFailure> Errors
        {
            get { return _results.SelectMany(x => x.Errors); }
        }

        public bool IsValid
        {
            get { return _results.All(x => x.IsValid); }
        }

        private readonly List<ValidationResult> _results = new List<ValidationResult>();
        public List<ValidationResult> Results
        {
            get { return _results; }
        }

        # endregion

        # region Methods

        public void Add(ValidationResult result)
        {
            _results.Add(result);
        }

        # endregion
    }
}
