using Common.FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;
using DomainContract.Contexts;
using APIContract.Utils;

namespace APIContract.Commands
{
    //command request
    public class DeleteUserCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }

    //fluent validation
    public class DeleteUserCommandValidator : AbstractModelValidator<DeleteUserCommand>
    {
        private readonly ContractDbContext _contractDbContext;
        public DeleteUserCommandValidator(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;

        }
    }

    //command handler
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly ContractDbContext _contractDbContext;
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        public DeleteUserCommandHandler(ContractDbContext contractDbContext, ILogger<DeleteUserCommandHandler> logger)
        {
            _contractDbContext = contractDbContext;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var query = await UserUtil.GetUserById(_contractDbContext, request.Id);

            _contractDbContext.Users.Remove(query);

            //commit transaction
            return await _contractDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
