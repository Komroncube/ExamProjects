namespace Library.Application.Abstractions.Messaging.Commands;
public interface ICommand : IRequest
{
}
public interface ICommand<TResponse> : IRequest<TResponse>
{ }