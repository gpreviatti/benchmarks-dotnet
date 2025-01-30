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
    public string State { get; set; }
    public string Neighbordhood { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
}

public record AccountRecordStruct
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string AccountType { get; set; }
    public Guid UserId { get; set; }
}