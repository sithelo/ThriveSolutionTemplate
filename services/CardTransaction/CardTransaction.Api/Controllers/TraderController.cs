// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CardTransaction.Api.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class TraderController : ControllerBase {
    private readonly IMediator _mediator;

    public TraderController(IMediator mediator) {
        _mediator = mediator;
    }
    [HttpPut(Name = "topup")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateTopUpCardCommand updateTopUpCardCommand)
    { 
        await _mediator.Send(updateTopUpCardCommand);
        return NoContent();
    }
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create([FromBody] CreateTraderCommand createTraderCommand)
    { 
        var response = await _mediator.Send(createTraderCommand);
        return Ok(response);
    }
}