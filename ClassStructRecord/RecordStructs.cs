namespace ClassStructRecord;

public record struct PersonRecordStruct
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }

    public AddressRecordStruct Address { get; set; }
    public List<AccountRecordStruct> Accounts { get; set; }
}

public record AddressRecordStruct
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
    public string Neighbordhood { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}

public record AccountRecordStruct
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}