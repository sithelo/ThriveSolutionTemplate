// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Events;
using MediatR;

namespace CardTransaction.Domain.Handlers; 

public class TraderToppedUpHandler : INotificationHandler<TraderToppedUpEvent> {
    public async Task Handle(TraderToppedUpEvent notification, CancellationToken cancellationToken) => throw new NotImplementedException();
}