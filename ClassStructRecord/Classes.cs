namespace ClassStructRecord;

public class PersonClass
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public AddressClass Address { get; set; }
    public List<AccountClass> Accounts { get; set; }
}

public class AddressClass
{
    public Guid Id { get; set; }
    public string State { get; set; }
    public string Neighbordhood { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
}

public class AccountClass
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string AccountType { get; set; }
    public Guid UserId { get; set; }
}