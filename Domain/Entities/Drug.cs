using Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity
{
    public Drug(string name, string manufacturer, string countryCodeId)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;

        Validate();
    }

    /// <summary>
    /// Название препарата.
    /// </summary>
    public string Name { get; private set; }
        
    /// <summary>
    /// Производитель препарата.
    /// </summary>
    public string Manufacturer { get; private set; }
        
    /// <summary>
    /// Код страны производителя.
    /// </summary>
    public string CountryCodeId { get; private set; }
    
    public Guid CountryId { get; private set; }
    // Навигационное свойство для связи с объектом Country
    public Country Country { get; private set; }
        
    // Навигационное свойство для связи с DrugItem
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    
    private void Validate()
    {
        var validator = new DrugValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join("\n", result.Errors);
            throw new ValidationException(errors);
        }
    }
}