using MediatR;

namespace Library.Application.Messaging.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{ }

