using PipelineMessenger.Handlers;
using PipelineMessenger.Tests.Pipelines.Entities;
using PipelineMessenger.Tests.Pipelines.Responses;

namespace PipelineMessenger.Tests.Pipelines.ResponseHandlers;

public class SingleTestEntityAResponseHandler : BasePreviousResultHandler<TestEntityAResponse, TestEntityA>
{
    protected override Task<TestEntityAResponse> HandleAsync(TestEntityA entity)
    {
        return Task.FromResult(new TestEntityAResponse()
        {
            Id = entity.Id,
            Name = entity.Name,
        });
    }
}