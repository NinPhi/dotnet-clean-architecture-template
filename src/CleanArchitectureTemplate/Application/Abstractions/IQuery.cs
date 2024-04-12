namespace Application.Abstractions;

/// <summary>
/// Interface representing a query. Always has return type.
/// </summary>
/// <typeparam name="TResponse">Return type.</typeparam>
internal interface IQuery<TResponse>
    : IRequest<Result<TResponse>>, IBaseQuery;
