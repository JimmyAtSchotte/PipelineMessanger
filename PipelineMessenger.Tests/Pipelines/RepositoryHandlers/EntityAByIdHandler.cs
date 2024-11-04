using PipelineMessenger.Handlers;
using PipelineMessenger.Tests.Pipelines.Entities;
using PipelineMessenger.Tests.Pipelines.Messages;

namespace PipelineMessenger.Tests.Pipelines.RepositoryHandlers;

public class EntityAByIdHandler : BaseMessageHandler<TestEntityA, IEntityByIdMessage>
{
  
    protected override Task<TestEntityA> HandleAsync(IEntityByIdMessage message)
    {
         return Task.FromResult(new TestEntityA(message.EntityId));
    }
}