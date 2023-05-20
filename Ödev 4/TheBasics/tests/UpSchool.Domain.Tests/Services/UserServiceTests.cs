﻿using FakeItEasy;
using System.Linq.Expressions;
using System.Threading;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;
using UpSchool.Domain.Utilities;

namespace UpSchool.Domain.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUser_ShouldGetUserWithCorrectId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() => userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token)).Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.GetByIdAsync(userId, cancellationSource.Token); 
            
            Assert.Equal(expectedUser, user);
        }

        // Homework starts from here.

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId,
                FirstName = "Şevval",
                LastName = "Barın",
                Age = 25,
                Email = ""
            };

            A.CallTo(() => userRepositoryMock.AddAsync(expectedUser, cancellationSource.Token));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.AddAsync(expectedUser.FirstName, expectedUser.LastName, expectedUser.Age, expectedUser.Email, cancellationSource.Token);

            Assert.Throws<ArgumentException>(() => user);
        }

        [Fact]
        public async Task AddAsync_ShouldReturn_CorrectUserId()
        {
            // ?

        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            var user = new User()
            {
                Id = Guid.NewGuid(),

            };

            A.CallTo(() => userRepositoryMock.DeleteAsync(A<Expression<Func<User, bool>>>.Ignored, cancellationSource.Token))
                .Returns(Task.FromResult(1));

            IUserService userService = new UserManager(userRepositoryMock);

            var result = await userService.DeleteAsync(user.Id, cancellationSource.Token);

            Assert.True(result);

        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            var user = new User()
            {
                Id = Guid.Empty,

            };

            IUserService userService = new UserManager(userRepositoryMock);

            var deletedUser = await userService.DeleteAsync(user.Id, cancellationSource.Token);

            Assert.Throws<ArgumentException>(() => deletedUser);
        }

        [Fact]
        public async void UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = Guid.Empty,
                FirstName = "Şevval",
                LastName = "Barın",
                Age = 25,
                Email = "sevval@gmail.com"
            };

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.UpdateAsync(expectedUser, cancellationSource.Token);

            Assert.Throws<ArgumentException>(() => user);
        }

        [Fact]
        public async void UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            var cancellationSource = new CancellationTokenSource();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var expectedUser = new User()
            {
                Id = userId,
                FirstName = "Şevval",
                LastName = "Barın",
                Age = 25,
                Email = String.Empty
            };

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.UpdateAsync(expectedUser, cancellationSource.Token);

            Assert.Throws<ArgumentException>(() => user);

        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            List<User> userList = new List<User>()
            {
                new User(){ Id = Guid.NewGuid() },
                new User() { Id = Guid.NewGuid() }
            };

            A.CallTo(() => userRepositoryMock.GetAllAsync(cancellationSource.Token))
                .Returns(Task.FromResult(userList));

            IUserService userService = new UserManager(userRepositoryMock);

            var expectedUserList = await userService.GetAllAsync(cancellationSource.Token);

            Assert.True(expectedUserList.Count >= 2);

        }

        // Homework ends here.

    }
}
