namespace ClassStructRecord;

public class PersonClass
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public AddressClass Address { get; set; } = new AddressClass();
    public List<AccountClass> Accounts { get; set; } = [];
}

public class AddressClass
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
    public string Neighbordhood { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}

public class AccountClass
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}