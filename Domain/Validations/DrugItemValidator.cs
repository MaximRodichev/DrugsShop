using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    /// <summary>
    /// Валидация DrugItem
    /// </summary>
    public DrugItemValidator()
    {
        /*- Cost
          - Положительное число.
          - Не более двух знаков после запятой.*/
        RuleFor(drugItem => drugItem.Cost)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GreaterThanOrEqualTo)
            .Must(cost => cost*100%1==0).WithMessage("Цена препарата должна быть до двух знаков после запятой");
        
        /*
          - Count
          - Целое неотрицательное число.
          - Максимум: 10 000.
         */
        RuleFor(drugItem => drugItem.Count)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .GreaterThan(0).WithMessage(ValidationMessages.GreaterThan)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessages.LessThanOrEqualTo);
        
        RuleFor(drugItem => drugItem.DrugId).
            NotEmpty().WithMessage(ValidationMessages.RequiredField);
        
        RuleFor(drugItem => drugItem.DrugStoreId).
            NotEmpty().WithMessage(ValidationMessages.RequiredField);
        
    }   
}