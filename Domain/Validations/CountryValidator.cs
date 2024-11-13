using FluentValidation;
using Domain.Entities;


namespace Domain.Validations;

public class CountryValidator : AbstractValidator<Country>
{
    /// <summary>
    /// Валидация Country
    /// </summary>
    public CountryValidator()
    {
        //CascadeMode = CascadeMode.StopOnFirstFailure;;
        //Правила для Названия страны
        RuleFor(country => country.Name)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField) //Так же проверяет на NULL
            .Length(2, 100).WithMessage(ValidationMessages.LenghtOutOfRange)
            // TODO: Не понятно "Только буквы и пробелы" Какие буквы и сколько пробелов максимум подряд
            .Matches("^([A-Za-z\\s]+|[А-Яа-я\\s]+)$").WithMessage(ValidationMessages.OnlyLettersAndWhiteSpaces) //Разрешит написание !полной строки на одном из языков и допустит неограниченное кол-во пробелов
            ;
        
        // //Проверка кода страны
        RuleFor(country => country.Code)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .Matches("^[A-Z]{2}$").WithMessage(ValidationMessages.CodeLetter);
    }
}