using PipelineMessenger.Handlers;
using PipelineMessenger.Tests.Pipelines.Entities;
using PipelineMessenger.Tests.Pipelines.Messages;

namespace PipelineMessenger.Tests.Pipelines.DomainHandlers;

public class UpdateEntityANameHandler : BaseHandler<TestEntityA, UpdateEntityANameMessage, TestEntityA>
{
    protected override Task<TestEntityA> Handle(UpdateEntityANameMessage message, TestEntityA entity)
    {
        entity.Name = message.Name;
        
        return Task.FromResult(entity);
    }
}