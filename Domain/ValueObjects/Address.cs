using Domain.Validations;
using FluentValidation;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Объект значения, представляющий адрес.
    /// </summary>
    public class Address : BaseValueObject
    {
        public Address(){}
        /// <summary>
        /// Конструктор для инициализации адреса.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="house">Номер дома.</param>
        /// <param name="postcode">Почтовый код</param>
        /// <param name="country">Страна</param>
        public Address(string city, string street, string house, string postcode, string country)
        {
            City = city;
            Street = street;
            House = house;
            PostalCode = postcode;
            Country = country;

            /*Validate().GetAwaiter();*/
        }
        
        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Улица.
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string House { get; private set; }
        
        /// <summary>
        /// Почтовый код
        /// </summary>
        public string PostalCode { get; private set; }

        /// <summary>
        /// Код страны
        /// </summary>
        public string Country { get; private set; }
        
        /// <summary>
        /// Возвращает строковое представление адреса.
        /// </summary>
        /// <returns>Строка, представляющая адрес.</returns>
        public override string ToString()
        {
            return $"{City}, {Street}, {House}, {PostalCode}, {Country}";
        }
        
        public async Task<bool> Validate()
        {
            var validator = new AddressValidator();
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