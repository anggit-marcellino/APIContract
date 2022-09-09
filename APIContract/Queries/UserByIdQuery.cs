using AutoMapper;
using DTO.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;
using DomainContract.Contexts;
using APIContract.Utils;

namespace APIContract.Queries
{
    //command
    public class UserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }

    //Queries handler
    public class UserByIdQueryHandler : IRequestHandler<UserByIdQuery, UserDto>
    {
        private readonly ContractDbContext _contractDbContext;
        private readonly ILogger<UserByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        public UserByIdQueryHandler(ContractDbContext contractDbContext, ILogger<UserByIdQueryHandler> logger, IMapper mapper)
        {
            _contractDbContext = contractDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await UserUtil.GetUserById(_contractDbContext, request.Id);

            return _mapper.Map<UserDto>(query);
        }
    }
}
