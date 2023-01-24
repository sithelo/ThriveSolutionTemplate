// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Clarity;
using Clarity.AspNetCore.Web;
using Microsoft.AspNetCore.Mvc;
using Transaction.Domain;
using static Transaction.Api.Application.Writes.TraderCommands;

namespace Transaction.Api.HttpApi.Traders; 

[Route("/card-transaction")]
public class CommandApi : CommandHttpApiBase<Trader> {
    public CommandApi(IApplicationService<Trader> service) : base(service) { }
    
    [HttpPost]
    [Route("profile")]
    public Task<ActionResult<Result>> CreateProfile([FromBody] CreateTrader cmd, CancellationToken cancellationToken)
        => Handle(cmd, cancellationToken);
}