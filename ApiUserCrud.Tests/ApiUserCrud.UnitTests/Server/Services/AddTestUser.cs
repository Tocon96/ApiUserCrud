using ApiUserCrud.BusinessLayer.Models;
using ApiUserCrud.BusinessLayer.Services;
using ApiUserCrud.DataAccess.Repositories;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.UnitTests.Server.Services
{
    public class AddTestUser
    {
        [Test]
        public void AddUser_To_Mock()
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

            int id = Task.Run(() => userService.AddUser(user)).Result;

            Assert.That(id, Is.EqualTo(0));
        }
    }
}
