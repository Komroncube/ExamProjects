namespace Library.Application.Abstractions;
public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken);
}
