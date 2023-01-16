// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace ThriveHttpCommand; 

public interface IExternalCommand {
    Task Post<T>(string   url, string path, T command, CancellationToken cancellationToken = default) where T: notnull;
    Task Put<T>(string    url, string path, T command, CancellationToken cancellationToken = default) where T: notnull;
    Task Delete<T>(string url, string path, T command, CancellationToken cancellationToken = default) where T: notnull;
}