using Bogus;

namespace Mappers;

public sealed class PersonEntityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public AddressEntityDto Address { get; set; } = new();
    public List<AccountEntityDto> Accounts { get; set; } = new();


    public static List<PersonEntityDto> GetPerson(int amountPeople, int amountAccounts = 1)
    {
        var _fakerPerson = new Faker<PersonEntityDto>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Accounts, f => AccountEntityDto.GetAccounts(amountAccounts));

        return _fakerPerson.Generate(amountPeople);
    }

    public static implicit operator PersonEntityDto(PersonEntity person) => new()
    {
        Id = person.Id,
        Name = person.Name,
        Email = person.Email,
        BirthDate = person.BirthDate,
        Address = person.Address,
        Accounts = [.. person.Accounts]
    };
}

public sealed class AddressEntityDto
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    public static AddressEntity GetAddress()
    {
        var _fakerAccount = new Faker<AddressEntity>("pt_BR");

        return _fakerAccount.Generate();
    }

    public static implicit operator AddressEntityDto(AddressEntity entity) => new()
    {
        Id = entity.Id,
        City = entity.City,
        ZipCode = entity.ZipCode,
        State = entity.State,
        Country = entity.Country,
        Neighborhood = entity.Neighborhood,
    };

}

public sealed class AccountEntityDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public Guid UserId { get; set; }

    public static List<AccountEntityDto> GetAccounts(int amount = 1)
    {
        var _fakerAccount = new Faker<AccountEntityDto>("pt_BR");

        return _fakerAccount.Generate(amount);
    }

    public static implicit operator AccountEntityDto(AccountEntity entity) => new()
    {
        Id = entity.Id,
        AccountType = entity.AccountType,
        Description = entity.Description,
        UserId = entity.UserId
    };
}