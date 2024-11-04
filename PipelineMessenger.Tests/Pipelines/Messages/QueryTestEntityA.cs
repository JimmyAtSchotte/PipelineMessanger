
using PipelineMessenger.Messaging;
using PipelineMessenger.Tests.Pipelines.Responses;

namespace PipelineMessenger.Tests.Pipelines.Messages;

public class QueryTestEntityA :  BaseMessage<TestEntityAResponse>, IEntityByIdMessage
{
    public Guid EntityId { get; set; }
}