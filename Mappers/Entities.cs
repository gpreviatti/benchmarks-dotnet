using Bogus;

namespace Mappers;

internal sealed class PersonEntity
{
    public PersonEntity()  { }

    public PersonEntity(
        Guid id, string name, string email, DateTime birthDate,
        AddressEntity address, List<AccountEntity> accounts
    )
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Address = address;
        Accounts = accounts;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public AddressEntity Address { get; set; } = new();
    public List<AccountEntity> Accounts { get; set; } = new();


    public static List<PersonEntity> GetPerson(int amountPeople, int amountAccounts = 1)
    {
        var _fakerPerson = new Faker<PersonEntity>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Accounts, f => AccountEntity.GetAccounts(amountAccounts));

        return _fakerPerson.Generate(amountPeople);
    }
}

internal sealed class AddressEntity
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
}

internal sealed class AccountEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public Guid UserId { get; set; }

    public static List<AccountEntity> GetAccounts(int amount = 1)
    {
        var fakerAccount = new Faker<AccountEntity>("pt_BR");

        return fakerAccount.Generate(amount);
    }
}