namespace ClassStructRecord;

public sealed class PersonSeleadClass
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public AddressSeleadClass Address { get; set; } = new AddressSeleadClass();
    public List<AccountSeleadClass> Accounts { get; set; } = [];
}

public sealed class AddressSeleadClass
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
    public string Neighbordhood { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}

public sealed class AccountSeleadClass
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}