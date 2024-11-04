public class Service : BaseEntity
{
    public string ServiceName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public string ServiceType { get; set; } = string.Empty;
    public int GymId { get; set; }
    public Gym? Gym { get; set; }
    public List<UserService> UserServices { get; set; }=[];
}