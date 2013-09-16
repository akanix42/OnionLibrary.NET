using System.Collections.Generic;
using System.Dynamic;
using FluentValidation.Results;
using LayeredDev.DAL;
using LayeredDev.ExceptionHandler;
using Newtonsoft.Json;

namespace LayeredDev.Responses
{
    public class DynamicResponse : DynamicObject, IResponse
    {
        // The inner dictionary.
        readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
        private readonly dynamic _self;// = this;
        private IEnumerable<DALError> _dalErrors;
        private IEnumerable<ValidationFailure> _validationErrors;
        private bool _wasSuccessful;

        public DynamicResponse()
        {
            _self = this;
            _self.WasSuccessful = false;

        }

        public override string ToString()
        {

            return JsonConvert.SerializeObject(_dictionary);
        }

        // If you try to get a value of a property  
        // not defined in the class, this method is called. 
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // If the property name is found in a dictionary, 
            // set the result parameter to the property value and return true. 
            // Otherwise, return false. 
            return _dictionary.TryGetValue(binder.Name, out result);
        }

        // If you try to set a value of a property that is 
        // not defined in the class, this method is called. 
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = value;

            // You can always add a value to a dictionary, 
            // so this method always returns true. 
            return true;
        }

        private void SetMember(string name, object value)
        {
            _dictionary[name] = value;

        }
        public IEnumerable<DALError> DALErrors
        {
            get { return _dalErrors; }
            set
            {
                _dalErrors = value;
                SetMember("DALErrors", value);
            }
        }

        public IEnumerable<ValidationFailure> ValidationErrors
        {
            get { return _validationErrors; }
            set
            {
                _validationErrors = value;
                SetMember("ValidationErrors", value);
            }
        }

        public bool WasSuccessful
        {
            get { return _wasSuccessful; }
            set
            {
                _wasSuccessful = value;
                SetMember("WasSuccessful", value);
            }
        }

        public IHandledException Exception { get; set; }
    }
}