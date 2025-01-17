﻿using PipelineMessenger.Messaging;

namespace PipelineMessenger.Handlers;

public interface IHandler
{
    bool HandlerAppliesTo(IMessage message, HandlerResult previousResult);
    Task<HandlerResult> HandleAsync(IMessage message, HandlerResult previousResult);
}
