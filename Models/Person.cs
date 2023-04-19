namespace SmallMVC.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<PhoneNumber> PhoneNumbers { get; set; }
    public List<Address> Addresses { get; set; }
    public SpouseDetails SpouseDetails { get; set; }
}