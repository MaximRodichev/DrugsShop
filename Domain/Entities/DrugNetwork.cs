using Domain.Validations;
using FluentValidation;

namespace Domain.Entities;

public class DrugNetwork : BaseEntity
{
    public DrugNetwork()
    {
        
    }
    public DrugNetwork(string name)
    {
        Name = name;
        Validate();
    }
    /// <summary>
    /// Имя сети аптек
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Навигационное свойство, для доступа ко всем аптекам
    /// </summary>
    public ICollection<DrugStore> Stores { get; set; }

    private void Validate()
    {
        var validator = new DrugNetworkValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join("\n", result.Errors);
            throw new ValidationException(errors);
        }
    }
}