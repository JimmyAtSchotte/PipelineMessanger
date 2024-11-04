using PipelineMessenger.Handlers;
using PipelineMessenger.Tests.Pipelines.Entities;
using PipelineMessenger.Tests.Pipelines.Messages;

namespace PipelineMessenger.Tests.Pipelines.RepositoryHandlers;

public class QueryAllEntityAHandler : BaseMessageHandler<TestEntityA[], QueryAllTestEntityA>
{
    protected override Task<TestEntityA[]> HandleAsync(QueryAllTestEntityA message)
    {
        return Task.FromResult(new[]
        {
            new TestEntityA(),
            new TestEntityA(),
            new TestEntityA(),
        });
    }
}