namespace Domain.Validations;

public static class ValidationMessages
{
    public const string NotNull = "Поле {PropertyName} не может быть нулевым.";
    public const string NotEmpty = "Поле {PropertyName} не может быть пустым.";
    public const string RequiredField = "Поле {PropertyName} обязательно.";
    public const string LenghtOutOfRange = "Длина введенного {PropertyName} меньше {MinLength} или больше {MaxLength}.";
    public const string EqualsLenght = "Длина {PropertyName} не равна {Lenght}";
    public const string GreaterThan = "Параметр {PropertyName} должен быть больше {ComparisonValue}";
    public const string GreaterThanOrEqualTo = "Параметр {PropertyName} должен быть равен или больше {ComparisonValue}";
    public const string LessThanOrEqualTo = "Параметр {PropertyName} должен быть равен или быть меньше {ComparisonValue}";
    public const string CodeLetter = "Параметр {PropertyName} не удовлетворяет условию: 2 заглавные латинские буквы";
    public const string OnlyLettersAndWhiteSpaces = "Параметр {PropertyName} не удовлетворяет условию: Только символы и пробелы";
    public const string ExcludeSpecialLetters = "Параметр {PropertyName} не удовлетворяет условию: Без специальных символов";
}