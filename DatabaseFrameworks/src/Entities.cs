namespace DatabaseFrameworks;

internal class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Address Address { get; set; } = new Address();
    public List<Account> Accounts { get; set; } = [];
}

internal class Address
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
    public string Neighbordhood { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}

internal class Account
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}