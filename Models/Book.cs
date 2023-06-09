public class Book
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string book { get; set; }
    public string Description { get; set; }
    public List<Reserve> Reserves { get; set; }
}