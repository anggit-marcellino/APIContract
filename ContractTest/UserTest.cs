using APIContract.Controllers;
using APIContract.Queries;
using APIContract.Utils;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContractTest
{
    public class UserTest
    {
        public Mock<UserUtil> userUtil;
        public Mock<UserByIdQuery> userByIdQuery;
        public Mock<UserGetAllQuery> userGetAllQuery;

        private UserController controller;
        public UserTest()
        {
            userUtil = new Mock<UserUtil>();
            userByIdQuery = new Mock<UserByIdQuery>();
            userGetAllQuery = new Mock<UserGetAllQuery>();
            //controller = new UserController(this.userUtil.Object, this.userByIdQuery.Object, this.userGetAllQuery);
        }
    }
}
    

