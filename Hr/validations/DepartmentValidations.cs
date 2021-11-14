using FluentValidation;
using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.validations
{
    public class DepartmentValidations : AbstractValidator<Department>
    {
        public DepartmentValidations()
        {
           
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}