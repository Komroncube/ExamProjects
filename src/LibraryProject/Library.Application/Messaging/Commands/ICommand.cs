using MediatR;

namespace Library.Application.Messaging.Commands;
public interface ICommand : IRequest
{
}
public interface ICommand<TResponse> : IRequest<TResponse>
{ }