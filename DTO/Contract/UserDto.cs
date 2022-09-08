using DomainContract.Entities;
using System;

namespace DTO.Contract
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }

    public class UserProfiles : BaseProfile
    {
        public UserProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}