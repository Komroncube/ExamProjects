using Library.Application.UseCases.Books.Queries.GetAllBooks;
using Library.Application.UseCases.Users.Queries.GetAllUsers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library.Application.Services;
public class BooksBackgrounService : BackgroundService
{
    private readonly ICacheService _cacheService;
    private readonly IServiceProvider serviceProvider;


    public BooksBackgrounService(ICacheService cacheService, IServiceProvider serviceProvider)
    {
        _cacheService = cacheService;
        this.serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
       
        using (var scope = serviceProvider.CreateScope())
        {
            IMediator _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            while (!stoppingToken.IsCancellationRequested)
            {
                var books = await _mediator.Send(new GetAllBooksQuery());
                await _cacheService.SetDataAsync(CacheKeys.BOOKSKEY, books, TimeSpan.FromSeconds(100));
 
                var users = await _mediator.Send(new GetAllUsersQuery(), stoppingToken);
                    await _cacheService.SetDataAsync(CacheKeys.USERSKEY, users, TimeSpan.FromSeconds(100));
                
                await Task.Delay(TimeSpan.FromSeconds(60));
            }
        }

    }
}
