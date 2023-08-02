using ApiUserCrud.BusinessLayer.Models;
using ApiUserCrud.BusinessLayer.Services;
using ApiUserCrud.DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Tests
{
    public class UserServiceTests
    {
        [Test]
        public async Task UserService_AddUser_Results()
        {
            var mockRepository = new Mock<IUserRepository>();
            var mockLogger = new Mock<ILogger<UserService>>();

            IUserService userService = new UserService(mockRepository.Object, mockLogger.Object);

            User user = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
            };

            int id = await userService.AddUser(user);

            Assert.That(id, Is.EqualTo(0));
        }
    }
}
