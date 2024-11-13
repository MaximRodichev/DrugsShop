using FluentValidation;
using Domain.Entities;

namespace Domain.Validations;

public class DrugValidator : AbstractValidator<Drug>
{
     /// <summary>
     /// Валидация препарата.
     /// </summary>
     public DrugValidator()
     {
          /*
            - Обязательное поле.
            - Длина: от 2 до 150 символов.
            - Без специальных символов.
           */
          RuleFor(drug => drug.Name)
               .NotEmpty().WithMessage(ValidationMessages.RequiredField)
               .Length(2, 150).WithMessage(ValidationMessages.LenghtOutOfRange)
               
               //.Matches("^[^!@#$%^&*]+$") // Первый подход, просто исключить "некоторые спец символы", можно упустить что-то и будут смайлы в названиях препарата
               
               .Matches("^([A-Za-zА-Яа-я0-9\\s.,№]+)$").WithMessage(ValidationMessages.ExcludeSpecialLetters) //второй подход, просто разрешаем что нам нужно, цифры буквы двух языков и некоторые символы
               //TODO: Такой подход даст true для Парацетомол 10табл. и для Paraцетомол 20табл. (Если целесообразно, можно усложить регулярное выражение)
               //TODO: Добавил №, т.к. на сайтах которые вы показывали данный символ присутствует в названиях (когда будем парсить их сайт вызовет проблему наше правило, поэтому сделано исключение)
               //TODO: http://e-apteka.md/products/Laktoflor_Opti_6_kaps__30 - Тут видно это (Лактофлор Опти 6 капс № 30, пищевая добавка)
               ;
          /*
          - Обязательное поле.
          - Длина: от 2 до 100 символов.
          - Только буквы, пробелы и дефисы.
          */
          RuleFor(drug => drug.Manufacturer)
               .NotEmpty().WithMessage(ValidationMessages.RequiredField)
               .Length(2, 100).WithMessage(ValidationMessages.LenghtOutOfRange)
               .Matches("^([A-Za-zА-Яа-я\\s-]+)$").WithMessage(ValidationMessages.ExcludeSpecialLetters); //TODO: Буквы какого языка?
          /*
           * - CountryCodeId
            - Ровно 2 заглавные латинские буквы.
            - Должен существовать в справочнике стран (Придумать, как это реализовать и проверять).
           */
          RuleFor(drug => drug.CountryCodeId)
              .Matches("^[A-Z]{2}$").WithMessage(ValidationMessages.CodeLetter)
              .Must((drug) => Country.AllowedCountriesCodes.Contains(drug)).WithMessage("Country Code is not allowed");
     }
}