namespace Application.Abstractions;

/// <summary>
/// Interface representing a command handler with no return type.
/// </summary>
/// <typeparam name="TCommand">Command type.</typeparam>
internal interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

/// <summary>
/// Interface representing a command handler with return type.
/// </summary>
/// <typeparam name="TCommand">Command type.</typeparam>
/// <typeparam name="TResponse">Return type.</typeparam>
internal interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;