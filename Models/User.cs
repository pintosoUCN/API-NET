public class User
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Faculty { get; set; }
    public List<Reserve> Reserves { get; set; }
}