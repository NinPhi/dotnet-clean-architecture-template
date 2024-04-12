namespace Application.Abstractions;

/// <summary>
/// Interface representing a query handler. Always has return type.
/// </summary>
/// <typeparam name="TQuery">Query type.</typeparam>
/// <typeparam name="TResponse">Return type.</typeparam>
internal interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
