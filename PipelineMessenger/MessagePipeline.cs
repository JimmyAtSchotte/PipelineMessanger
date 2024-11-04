using PipelineMessenger.Messaging;
using PipelineMessenger.Pipelines;

namespace PipelineMessenger;

public class MessagePipeline(IPipeline[] pipelines)
{
    public async Task<TResult?> HandleAsync<TResult>(IMessage<TResult> message) 
        where TResult : class
    {
        var currentResult = HandlerResult.Empty();
        
        foreach (var pipeline in pipelines)
            currentResult = await pipeline.HandleAsync(message, currentResult);

        return currentResult.TryGetValue<TResult>(out var result) 
            ? result 
            : default;
    }
}