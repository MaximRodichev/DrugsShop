using System.Data;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class DrugNetworkValidator : AbstractValidator<DrugNetwork>
{
    public DrugNetworkValidator()
    {
        RuleFor(x=> x.Name)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .Length(2,100).WithMessage(ValidationMessages.LenghtOutOfRange);
    }
}