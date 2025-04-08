public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Document> Documents { get; set; }
    public DbSet<IngestionStatus> IngestionStatuses { get; set; }
}
