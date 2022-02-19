using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class PermissionsValidator : AbstractValidator<PermissionsDto>
    {
		public PermissionsValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("User's Name is required");
			RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required");
		}
	}
}
