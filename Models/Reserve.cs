public class Reserve
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int User_Id { get; set; }
    public int Book_Id { get; set; }
    public DateTime Reserved_At { get; set; }
    public User User { get; set; }
    public Book Book { get; set; }
}