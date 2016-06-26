using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sterling.Hr.Logic;
using Rhino.Mocks;

namespace Sterling.Hr.Logic.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService concern;

        [TestMethod]
        public void Successfully_Returns_All_Users_When_Passing_In_False()
        {
            // unit test goes here
            var allUsers = new User[] { new User(), new User(), new User(), new User() };

            //mock objects
            var stubUserDataAccess = MockRepository.GenerateStub<IUserDataAccess>();
            stubUserDataAccess.Stub(x => x.GetAllUsers()).Return(allUsers);

            //run tests
            concern = new UserService(stubUserDataAccess);
            var result = concern.GetUsers(false);

            //assert
            stubUserDataAccess.AssertWasCalled(x => x.GetAllUsers());
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length, 4);
        }

        [TestMethod]
        public void Successfully_Returns_All_Active_Users_When_Passing_In_True()
        {
            // unit test goes here
            var activeUsers = new User[] { new User(), new User() };

            //mock objects
            var stubUserDataAccess = MockRepository.GenerateStub<IUserDataAccess>();
            stubUserDataAccess.Stub(x => x.GetAllActiveUsers()).Return(activeUsers);

            //run tests
            concern = new UserService(stubUserDataAccess);
            var result = concern.GetUsers(true);

            //assert
            stubUserDataAccess.AssertWasCalled(x => x.GetAllActiveUsers());
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length, 2);
        }
    }
}
