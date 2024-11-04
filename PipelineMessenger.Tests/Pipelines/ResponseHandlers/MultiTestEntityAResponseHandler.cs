using PipelineMessenger.Handlers;
using PipelineMessenger.Tests.Pipelines.Entities;
using PipelineMessenger.Tests.Pipelines.Responses;

namespace PipelineMessenger.Tests.Pipelines.ResponseHandlers;

public class MultiTestEntityAResponseHandler : BasePreviousResultHandler<TestEntityAResponse[], TestEntityA[]>
{
 
    protected override Task<TestEntityAResponse[]> HandleAsync(TestEntityA[] entities)
    {
        return Task.FromResult(entities.Select(entity => new TestEntityAResponse()
        {
            Id = entity.Id,
            Name = entity.Name,
        }).ToArray());
    }
}