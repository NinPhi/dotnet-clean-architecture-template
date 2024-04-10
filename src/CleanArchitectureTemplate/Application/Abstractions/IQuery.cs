using Domain.Result;
using MediatR;

namespace Application.Abstractions;

internal interface IQuery<TResponse>
    : IRequest<Result<TResponse>>, IBaseQuery;
