namespace Application.Abstractions;

/// <summary>
/// Interface representing a command with no return type.
/// </summary>
internal interface ICommand
    : IRequest<Result>, IBaseCommand;

/// <summary>
/// Interface representing a command with return type.
/// </summary>
/// <typeparam name="TResponse">Return type.</typeparam>
internal interface ICommand<TResponse>
    : IRequest<Result<TResponse>>, IBaseCommand;
