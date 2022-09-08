using Common.Exceptions;
using System.Security.Principal;
using System.Threading.Tasks;
using System;
using DomainContract.Contexts;
using DomainContract.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace APIContract.Utils
{
    public class UserUtil
    {
        public static async Task<User> GetAccountById(ContractDbContext contractDbContext, Guid Id)
        {
            var query = await contractDbContext.Users
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            if (query is null)
            {
                throw new NotFoundException("User is not found!");
            }

            return query;
        }

        public static async Task<bool> IsUserExist(ContractDbContext contractDbContext, string UserName)
        {
            var query = await contractDbContext.Users
                .Where(x => x.UserName == UserName)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                throw new ConflictException("UserName already exists!");
            }

            return false;
        }

    }
}
