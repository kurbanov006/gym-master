public class UserTrainer : BaseUser
{
    public string Specialization { get; set; } = string.Empty;
    public DateTime CareerStart { get; set; }
    public int GymId { get; set; }
    public Gym? Gym { get; set; }
    public List<UserService> UserServices { get; set; } = [];
}