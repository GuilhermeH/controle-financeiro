using System;
using System.Collections.Generic;
using System.Text;

namespace controle.financeiro.shared.Entities
{
    public abstract class ErrorTracker
    {
        private readonly List<Error> _errors;

        public ErrorTracker()
        {
            _errors = new List<Error>();
        }

        public bool IsValid()
        {
            return _errors.Count == 0;
        }

        public void AddErrors(List<Error> errors)
        {
            _errors.AddRange(errors);
        }

        public void AddError(Error error)
        {
            _errors.Add(error);
        }

        public IEnumerable<Error> GetErrors() => _errors;
    }
}
