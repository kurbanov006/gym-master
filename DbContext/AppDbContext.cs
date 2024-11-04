using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Gym> Gyms { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<UserClient> UserClients { get; set; }
    public DbSet<UserTrainer> UserTrainers { get; set; }
    public DbSet<UserService> UserServices { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
    }
}