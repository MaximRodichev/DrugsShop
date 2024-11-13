using System.ComponentModel.DataAnnotations;
using Domain.Validations;

namespace Domain.Entities;

/// <summary>
/// Справочник стран
/// </summary>
public class Country : BaseEntity
{   
    //TODO: Хэш сет хранится только в оперативной памяти, поэтому тут нужно сделать инверсию зависимости и записывать из контекста бд, все текущие страны, которые там есть.
    public static readonly HashSet<string> AllowedCountriesCodes = new HashSet<string>() //Статическое поле для хранения созданных стран
    {
        "RU", "US", "CA", "GB", "FR", "DE", "IT", "ES", "JP", "CN"
    };
    /// <summary>
    /// Конструктор для инициализации страны с названием и кодом.
    /// </summary>
    /// <param name="name">Название страны.</param>
    /// <param name="code">Код страны.</param>
    public Country(string name, string code)
    {
        Name = name;
        Code = code;
        Validate();
        if (!AllowedCountriesCodes.Contains(code))
        {
            AllowedCountriesCodes.Add(Code); //Добавляем в хэш сет (справочник) новую страну после валидации.
        }
    }

    /// <summary>
    /// Название страны.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Код страны (например, ISO-код).
    /// </summary>
    public string Code { get; private set; }
        
    // Навигационное свойство для связи с препаратами
    public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
    
    //Валидация
    private void Validate()
    {
        var validator = new CountryValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join("\n", result.Errors);
            throw new ValidationException(errors);
        }
    }
}