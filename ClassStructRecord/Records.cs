namespace ClassStructRecord;

public record PersonRecord
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public AddressRecord Address { get; set; } = new AddressRecord();
    public List<AccountRecord> Accounts { get; set; } = [];
}

public record AddressRecord
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
    public string Neighbordhood { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}

public record AccountRecord
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}