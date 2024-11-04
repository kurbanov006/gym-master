public class UserService : BaseEntity
{

    public int UserClientId { get; set; }
    public UserClient? UserClient { get; set; }

    public int UserTrainerId { get; set; }
    public UserTrainer? UserTrainer { get; set; }

    public int ServiceId { get; set; }
    public Service? Service { get; set; }
    // Дата Последней оплаты
    public DateTime LastPayMentDate { get; set; }
}