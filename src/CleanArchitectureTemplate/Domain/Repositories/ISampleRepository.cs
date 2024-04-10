using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;

internal interface ISampleRepository : IRepository<Sample>
{
    void SetType(SampleType type);
}