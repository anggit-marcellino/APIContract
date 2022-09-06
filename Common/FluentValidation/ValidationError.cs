using System.Collections.Generic;

namespace Common.FluentValidation
{
    public class ValidationError
    {
        public int Status { get; set; }

        public List<PropertyError> Messages { get; set; }
    }
}
