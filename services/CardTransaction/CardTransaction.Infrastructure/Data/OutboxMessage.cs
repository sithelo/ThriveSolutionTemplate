// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace CardTransaction.Infrastructure.Data;

public sealed class OutboxMessage {
    public Guid           Id          { get; set; }
    public string         Type        { get; set; } = string.Empty;
    public string         Content     { get; set; } = string.Empty;
    public DateTimeOffset OccurredOn  { get; set; }
    public DateTimeOffset? ProcessedOn { get; set; }
    public string?        Error       { get; set; }
}