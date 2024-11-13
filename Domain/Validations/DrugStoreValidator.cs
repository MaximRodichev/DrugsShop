using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {

        RuleFor(x => x.DrugNetwork)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField);
        
        RuleFor(x => x.Number)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .GreaterThan(0).WithMessage(ValidationMessages.GreaterThan)
            .Must(x => x is int);
        
        //TODO: Не знаю как асинхронную валидацию запихнуть в конструктор класса
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField);
           /* .SetValidator(new AddressValidator());*/
        
        RuleForEach(network => network.DrugNetwork.Stores).ChildRules(
            store =>
            {
                store.RuleFor(s => s.Number)
                    .Must((store, number) => number == store.Number).WithMessage("Invalid number");
            });
    }
}