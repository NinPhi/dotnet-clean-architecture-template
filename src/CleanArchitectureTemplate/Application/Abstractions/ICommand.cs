using Domain.Result;
using MediatR;

namespace Application.Abstractions;

internal interface ICommand
    : IRequest<Result>, IBaseCommand;

internal interface ICommand<TResponse>
    : IRequest<Result<TResponse>>, IBaseCommand;
