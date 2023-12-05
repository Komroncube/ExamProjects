using MediatR;

namespace Library.Application.Abstractions.Messaging.Queries;

public interface IQuery<TResponse> : IRequest<TResponse>
{ }
