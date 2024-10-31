using Domain.ValueObjects;

namespace Domain.Entities;

public class DrugStore : BaseObject
{
    public Address Address { get; set; }
    public string DrugsNetwork { get; set; }
}