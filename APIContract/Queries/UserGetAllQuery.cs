using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using DTO.Contract;
using DomainContract.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace APIContract.Queries
{

    //command request
    public class UserGetAllQuery : IRequest<List<UserDto>> { }
    //Queries handler    
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, List<UserDto>>
    {
        private readonly ContractDbContext _contractDbContext;
        private readonly ILogger<UserGetAllQueryHandler> _logger;
        private readonly IMapper _mapper;
        public UserGetAllQueryHandler(ContractDbContext contractDbContext, ILogger<UserGetAllQueryHandler> logger, IMapper mapper)
        {
            _contractDbContext = contractDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                #region Sumber Data
                var query = await _contractDbContext.Users
                    .Select(x => _mapper.Map<UserDto>(x))
                    .AsNoTracking()
                    .ToListAsync();
                #endregion

                return query;
            }
            catch (Exception) { throw; }
        }
    }
}
