namespace Four;

public class User
{
    public string Name { get; private set; }
    
    public string Email { get; private set; }

    private readonly List<Address> _addresses;
    
    public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();

    public User(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        
        Name = name;
        Email = email;
        _addresses = new List<Address>();
    }
    
    public void AddAddress(Address address)
    {
        if (address == null)
            throw new ArgumentNullException(nameof(address));
        
        _addresses.Add(address);
    }

    public bool RemoveAddress(Address address)
    {
        if (address == null)
            throw new ArgumentNullException(nameof(address));
        
        return _addresses.Remove(address);
    }

    public void ClearAddresses()
    {
        _addresses.Clear();
    }
}