using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class PermissionTypeValidator : AbstractValidator<PermissionTypeDto>
    {
		public PermissionTypeValidator()
		{
			RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
		}
	}
}
