using FluentValidation;
using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.validations
{
    public class EmployeeValidations : AbstractValidator<Employee>
    {
        public EmployeeValidations()
        {
            RuleFor(x => x.DeptId).NotNull().GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.title).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.EmpNumber).NotEmpty().WithMessage("Employee Number is required.");
        }
    }
}
