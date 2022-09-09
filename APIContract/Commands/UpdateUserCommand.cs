using AutoMapper;
using Common.FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;
using DTO.Contract;
using DomainContract.Contexts;
using FluentValidation;
using System.Linq;
using DomainContract.Entities;
using APIContract.Utils;

namespace APIContract.Commands
{
    //command request
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }

    //fluent validation
    public class UpdateUserCommandValidator : AbstractModelValidator<UpdateUserCommand>
    {
        private readonly ContractDbContext _contractDbContext;
        public UpdateUserCommandValidator(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;
            RuleFor(x => x.UserName)
                .NotEmpty()
                .Must(val =>
                {
                    User user = _contractDbContext.Users.FirstOrDefault(x => x.UserName == val);
                    return user == null;
                });
        }
    }

    //command handler
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly ContractDbContext _contractDbContext;
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(ContractDbContext contractDbContext, ILogger<UpdateUserCommandHandler> logger, IMapper mapper)
        {
            _contractDbContext = contractDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await UserUtil.GetUserById(_contractDbContext, request.Id);

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.Password = request.Password;

            _contractDbContext.Users.Update(user);
            await _contractDbContext.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
