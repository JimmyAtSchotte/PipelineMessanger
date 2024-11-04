using PipelineMessenger.Messaging;
using PipelineMessenger.Tests.Pipelines.Responses;

namespace PipelineMessenger.Tests.Pipelines.Messages;

public interface IEntityByIdMessage : IMessage
{
    Guid EntityId { get; }
}

public class UpdateEntityANameMessage :  BaseMessage<TestEntityAResponse>, IEntityByIdMessage
{
    public Guid EntityId { get; set; }
    public string Name { get; set; }
}