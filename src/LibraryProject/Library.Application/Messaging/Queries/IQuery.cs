using MediatR;

namespace Library.Application.Messaging.Queries;

public interface IQuery<TResponse> : IRequest<TResponse>
{ }
