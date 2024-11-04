using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PipelineMessenger.DependencyInjection;
using PipelineMessenger.Tests.Pipelines.DomainHandlers;
using PipelineMessenger.Tests.Pipelines.Entities;
using PipelineMessenger.Tests.Pipelines.Messages;
using PipelineMessenger.Tests.Pipelines.RepositoryHandlers;
using PipelineMessenger.Tests.Pipelines.ResponseHandlers;
using PipelineMessenger.Tests.Pipelines.Responses;

namespace PipelineMessenger.Tests;

public class Tests
{
    private MessagePipeline _messagePipeline;
    
    [SetUp]
    public void Setup()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMessagePipeline(builder =>
        {
            builder.AddPipeline(typeof(EntityAByIdHandler), typeof(QueryAllEntityAHandler));
            builder.AddPipeline(typeof(UpdateEntityANameHandler));
            builder.AddPipeline(typeof(SingleTestEntityAResponseHandler), typeof(MultiTestEntityAResponseHandler));
        });
        
        var provider = serviceCollection.BuildServiceProvider();
        _messagePipeline = provider.GetRequiredService<MessagePipeline>();
    }
    
    
    [Test]
    public async Task ShouldMutateEntityInPipeline()
    {
        var command = new UpdateEntityANameMessage()
        {
            EntityId = Guid.NewGuid(),
            Name = "Test"
        };
        
        var result = await _messagePipeline.HandleAsync(command);
        result.Should().BeOfType<TestEntityAResponse>();
        result.Id.Should().Be(command.EntityId);
        result.Name.Should().Be(command.Name);
    }
    
    [Test]
    public async Task ShouldSkipPipelinesWithNoHandlers()
    {
        var command = new QueryTestEntityA()
        {
            EntityId = Guid.NewGuid()
        };
        
        var result = await _messagePipeline.HandleAsync(command);
        result.Should().BeOfType<TestEntityAResponse>();
    }
    
    [Test]
    public async Task ShouldInvokeMatchingHandlerMultipleTimesToCreateAnArray()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMessagePipeline(options =>
        {
            options.AddPipeline(typeof(QueryAllEntityAHandler));
            options.AddPipeline(typeof(SingleTestEntityAResponseHandler));
        });
        
        var provider = serviceCollection.BuildServiceProvider();
        var messagePipeline = provider.GetRequiredService<MessagePipeline>();
        
        var command = new QueryAllTestEntityA()
        {
            
        };
        
        var result = await messagePipeline.HandleAsync(command);
        result.Should().BeOfType<TestEntityAResponse[]>();
    }

    [Test]
    public void ShouldApplyToHandlerWhenResultIsAnArrayButExpectsSingleResult()
    {
        var handler = new SingleTestEntityAResponseHandler();
        
       handler
           .HandlerAppliesTo(new QueryAllTestEntityA(), HandlerResult.Success(new[] { new TestEntityA() }))
           .Should().BeTrue();
    }
}