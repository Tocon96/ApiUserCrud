using ApiUserCrud.Client.DataAccess.Utils;
using ApiUserCrud.Client.DataAccess.DataProviders;
using ApiUserCrud.Client.DataAccess.Repositories;
using Moq;
using ApiUserCrud.Client.DataAccess.Models;
using ApiUserCrud.Client.DataAccess;
using Grpc.Core;
using ApiUserCrud.Client.Tests.Helpers;

namespace ApiUserCrud.Client.Tests
{
    public class UserRepositoryTests
    {
        [Test]
        public async Task UserRepository_AddUser_Returns()
        {
            var mockClient = new Mock<UserGrpc.UserGrpcClient>();
            var mockCall = CallHelpers.CreateAsyncUnaryCall(new AddUserId { Id = 1 });
            var mockLogger = new Mock<ILogger>();

            mockClient.Setup(s => s.AddUserAsync(It.IsAny<AddUserDetails>(), null, null, It.IsAny<CancellationToken>())).Returns(mockCall);

            IUserRepository userRepository = new UserRepository(mockClient.Object, mockLogger.Object);

            var reply = await userRepository.AddUser("test", "test", "test");

            Assert.That(reply, Is.EqualTo(1));
        }

        [Test]
        public async Task UserRepository_DeleteUser_Returns()
        {
            var mockClient = new Mock<UserGrpc.UserGrpcClient>();
            var mockCall = CallHelpers.CreateAsyncUnaryCall(new DeleteUserConfirmation { Deleted = true });
            var mockLogger = new Mock<ILogger>();

            mockClient.Setup(s => s.DeleteUserAsync(It.IsAny<DeleteUserId>(), null, null, It.IsAny<CancellationToken>())).Returns(mockCall);

            IUserRepository userRepository = new UserRepository(mockClient.Object, mockLogger.Object);

            var reply = await userRepository.DeleteUser(1);

            Assert.That(reply, Is.True);
        }

        [Test]
        public async Task UserRepository_UpdateUser_Returns()
        {
            var mockClient = new Mock<UserGrpc.UserGrpcClient>();
            var mockCall = CallHelpers.CreateAsyncUnaryCall(new UpdateUserId { Id = 1 });
            var mockLogger = new Mock<ILogger>();

            mockClient.Setup(s => s.UpdateUserAsync(It.IsAny<UpdateUserDetails>(), null, null, It.IsAny<CancellationToken>())).Returns(mockCall);

            IUserRepository userRepository = new UserRepository(mockClient.Object, mockLogger.Object);

            var reply = await userRepository.UpdateUser(1, "test", "test", "test");

            Assert.That(reply, Is.EqualTo(1));
        }

        [Test]
        public async Task UserRepository_GetUser_Returns()
        {
            UserGrpcModel userGrpcModel = new UserGrpcModel
            {
                Id = 1,
                FirstName = "testFirstName",
                LastName = "testLastName",
                Email = "testEmail"
            };

            var mockClient = new Mock<UserGrpc.UserGrpcClient>();
            var mockCall = CallHelpers.CreateAsyncUnaryCall(new GetUserDetails { User = userGrpcModel });
            var mockLogger = new Mock<ILogger>();

            mockClient.Setup(s => s.GetUserAsync(It.IsAny<GetUserId>(), null, null, It.IsAny<CancellationToken>())).Returns(mockCall);

            IUserRepository userRepository = new UserRepository(mockClient.Object, mockLogger.Object);

            var reply = await userRepository.GetUser(1);

            Assert.That(reply.FirstName, Is.EqualTo("testFirstName"));
            Assert.That(reply.LastName, Is.EqualTo("testLastName"));
            Assert.That(reply.Email, Is.EqualTo("testEmail"));
        }

        [Test]
        public async Task UserRepository_GetUsers_Returns()
        {
            GetUsersDetails userGrpcModels = new GetUsersDetails();

            for(int i = 0; i < 10; i++)
            {
                UserGrpcModel userGrpcModel = new UserGrpcModel
                {
                    Id = i,
                    FirstName = "testFirstName",
                    LastName = "testLastName",
                    Email = "testEmail"
                };

                userGrpcModels.User.Add(userGrpcModel);
            }

            var mockClient = new Mock<UserGrpc.UserGrpcClient>();
            var mockCall = CallHelpers.CreateAsyncUnaryCall(new GetUsersDetails(userGrpcModels));
            var mockLogger = new Mock<ILogger>();

            mockClient.Setup(s => s.GetUsersAsync(It.IsAny<Empty>(), null, null, It.IsAny<CancellationToken>())).Returns(mockCall);

            IUserRepository userRepository = new UserRepository(mockClient.Object, mockLogger.Object);

            var reply = await userRepository.GetUsers();

            Assert.That(reply.Count, Is.EqualTo(10));
        }
    }
}