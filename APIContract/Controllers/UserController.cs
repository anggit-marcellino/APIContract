using Common.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using APIContract.Queries;
using APIContract.Commands;
using Microsoft.AspNetCore.Authorization;
using DTO.Contract;

namespace APIContract.Controllers
{
    [Route("api/auth/register")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        protected readonly ILogger<UserController> _logger;
        protected readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var result = await _mediator.Send(new UserGetAllQuery());
            var status = StatusCodes.Status200OK;
            var response = ResponseFactory<List<UserDto>>.SuccessResponse(status, result);
            return new OkObjectResult(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new UserByIdQuery() { Id = id });
            var status = StatusCodes.Status200OK;
            var response = ResponseFactory<UserDto>.SuccessResponse(status, result);
            return new OkObjectResult(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserDto>> Create([FromForm] CreateUserCommand request)
        {
            var result = await _mediator.Send(request);
            var status = StatusCodes.Status201Created;
            var response = ResponseFactory<UserDto>.SuccessResponse(status, result);

            return CreatedAtAction(nameof(GetById), new
            {
                Id = result.Id
            },
            response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDto>> Update([FromForm] UpdateUserCommand request)
        {
            var result = await _mediator.Send(request);
            var status = StatusCodes.Status200OK;
            var response = ResponseFactory<UserDto>.SuccessResponse(status, result);
            return new OkObjectResult(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserCommand request)
        {

            var result = await _mediator.Send(request);
            return new OkResult();

        }
    }

}