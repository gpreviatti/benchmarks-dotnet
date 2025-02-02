using Bogus;
using ProtoBuf;

namespace JsonCerverterxJsonSerializerxProtobuffer;

[ProtoContract]
public class PersonProto
{
    [ProtoMember(1)]
    public Guid Id { get; set; }
    [ProtoMember(2)]
    public string Name { get; set; }
    [ProtoMember(3)]
    public string Email { get; set; }
    [ProtoMember(4)]
    public DateTime BirthDate { get; set; }

    [ProtoMember(5)]
    public AddressProto Address { get; set; }

    [ProtoMember(6)]
    public List<AccountProto> Accounts { get; set; }


    public static List<PersonProto> GetPerson(int amountPeople, int amountAccounts = 1)
    {
        var _fakerPerson = new Faker<PersonProto>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Id, f => f.Random.Uuid())
            .RuleFor(c => c.Name, f => f.Person.FirstName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(c => c.Address, f => AddressProto.GetAddress())
            .RuleFor(c => c.Accounts, f => AccountProto.GetAccounts(amountAccounts));

        return _fakerPerson.Generate(amountPeople);
    }
}

[ProtoContract]
public class AddressProto
{
    [ProtoMember(1)]
    public Guid Id { get; set; }

    [ProtoMember(2)]
    public string State { get; set; }

    [ProtoMember(3)]
    public string Neighbordhood { get; set; }

    [ProtoMember(4)]
    public string Country { get; set; }

    [ProtoMember(5)]
    public string City { get; set; }

    [ProtoMember(6)]
    public string ZipCode { get; set; }

    public static AddressProto GetAddress()
    {
        var _fakerAccount = new Faker<AddressProto>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Id, f => f.Random.Uuid())
            .RuleFor(c => c.State, f => f.Address.StreetAddress())
            .RuleFor(c => c.Country, f => f.Address.Country())
            .RuleFor(c => c.Neighbordhood, f => f.Address.FullAddress())
            .RuleFor(c => c.City, f => f.Address.City())
            .RuleFor(c => c.ZipCode, f => f.Address.ZipCode());

        return _fakerAccount.Generate();
    }
}

[ProtoContract]
public class AccountProto
{
    [ProtoMember(1)]
    public Guid Id { get; set; }

    [ProtoMember(2)]
    public string Description { get; set; }

    [ProtoMember(3)]
    public string AccountType { get; set; }

    [ProtoMember(4)]
    public Guid UserId { get; set; }

    public static List<AccountProto> GetAccounts(int amount = 1)
    {
        var _fakerAccount = new Faker<AccountProto>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Id, f => f.Random.Uuid())
            .RuleFor(c => c.Description, f => f.Finance.AccountName())
            .RuleFor(c => c.AccountType, f => f.Finance.TransactionType())
            .RuleFor(c => c.UserId, f => f.Random.Uuid());
        return _fakerAccount.Generate(amount);
    }
}