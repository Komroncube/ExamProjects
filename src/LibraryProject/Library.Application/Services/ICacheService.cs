namespace Library.Application.Services;
public interface ICacheService
{
    public ValueTask<T?> GetDataAsync<T>(string key, CancellationToken cancellationToken = default);
    public ValueTask<bool> RemoveDataAsync(string key, CancellationToken cancellationToken = default);
    public ValueTask<bool> RefreshDataAsync<T>(string key, T value, TimeSpan expiretime, CancellationToken cancellationToken = default);
    public ValueTask<bool> SetDataAsync<T>(string key, T value, TimeSpan expiretime, CancellationToken cancellationToken = default);
}
