using System.Text.Json;
using Domain.ValueObjects;
using FluentValidation;
namespace Domain.Validations;


public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .Length(3,100).WithMessage(ValidationMessages.LenghtOutOfRange);
        
        RuleFor(x => x.City)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .Length(2,50).WithMessage(ValidationMessages.LenghtOutOfRange);
        
        //TODO: Почтовый код для приднестровья это 4 числа, не 5 и не 6, или же набор из букв:
        //TODO: MD-3300 или просто 3300
        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .Length(5,6).WithMessage(ValidationMessages.LenghtOutOfRange)
            .Matches("^[0-9]+$").WithMessage("Contain only numbers");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage(ValidationMessages.RequiredField)
            .MustAsync(async (c,cancellation) => await GetCurrentlyCode(c)).WithMessage("Not a valid country");

        
    }
    private async Task<bool> GetCurrentlyCode(string c)
    {
        var httpClient = new HttpClient();
        var baseUrl =
            $"https://public.opendatasoft.com/api/explore/v2.1/catalog/datasets/countries-codes/records?select=onu_code&where=onu_code%20%3D%20%27{c}%27&";
        try
        {
            var response = await httpClient.GetStringAsync(baseUrl);
            
            // Парсинг JSON-ответа
            using var document = JsonDocument.Parse(response);
            
            // Извлечение onu_code из JSON
            var onuCode = document
                .RootElement
                .GetProperty("results")[0]
                .GetProperty("onu_code")
                .GetString();
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching ONU code: {ex.Message}");
            return false;
        }
    }
}