// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace ThriveAzureServiceBus.Interfaces; 

public interface IMessageBusFactory {
  IMessageBus GetClient(string connectionString, string sender);
}