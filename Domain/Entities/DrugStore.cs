using Domain.Validations;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class DrugStore : BaseEntity
    {
        public DrugStore()
        {
            
        }
        public DrugStore(DrugNetwork drugNetwork, int number, Address address)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;
            //Ожидаем выполнение асинхронной функции принудительно
            Validate().GetAwaiter().GetResult();
            DrugNetwork.Stores.Add(this);
        }

        
        public Guid DrugNetworkId { get; private set; }
        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        
        public DrugNetwork DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
        
        private async Task<bool> Validate()
        {
            var validator = new DrugStoreValidator();
            var result = await validator.ValidateAsync(this);

            if (!result.IsValid)
            {
                var errors = string.Join("\n", result.Errors);
                throw new ValidationException(errors);
            }

            return true;
        }
    }
}