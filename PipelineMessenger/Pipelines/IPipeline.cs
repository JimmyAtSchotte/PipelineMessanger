using PipelineMessenger.Messaging;

namespace PipelineMessenger.Pipelines;

public interface IPipeline
{
    Task<HandlerResult> HandleAsync(IMessage message, HandlerResult previousResult);
}