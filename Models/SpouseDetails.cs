namespace SmallMVC.Models;

public class SpouseDetails
{
    public int Id { get; set; }
    public string MaritalStatus { get; set; }
    public int? SpouseId { get; set; }
    public int? PersonId { get; set; }
}