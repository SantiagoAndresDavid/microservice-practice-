namespace API.Entities;

public class Base
{
    public Guid Id { get; set; }
    public bool type { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifyDate { get; set; }
}