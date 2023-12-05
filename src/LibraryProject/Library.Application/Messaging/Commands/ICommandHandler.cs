﻿using MediatR;

namespace Library.Application.Messaging.Commands;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{ }
