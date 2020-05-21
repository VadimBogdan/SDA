using AutoFixture;
using AutoFixture.NUnit3;
using BLL;
using DAL.Repositories;
using DAL.RepositoryInterfaces;
using DAL.UnitOfWork;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTests
{
    [TestFixture]
    public class BoardServiceTests
    {
        public IBoardService boardService;
        public UnitOfWork unitOfWork;

        [Test]
        [InlineAutoData("user", "123")]
        public void AuthorizeUser_Should_Return_User_WithSameLoginAndPassword_If_UserExists(string login, string password)
        {
            // arrange
            unitOfWork = Substitute.For<UnitOfWork>(new object[] { null });
            unitOfWork.GetRepository<IUserRepository>().GetByLoginAndPass(login, password)
                .Returns(new DAL.Model.User { Login = login, Password = password });
            boardService = new BoardService(unitOfWork);
            // act
            var user = boardService.AuthorizeUser(login, password);
            // assert
            Assert.AreEqual(login, user.Login);
            Assert.AreEqual(password, user.Password);
        }

        [Test, AutoData]
        public void ValidateUserLoginExist_Should_Return_True_If_UserWithSuchLoginExists(string login)
        {
            // arrange
            unitOfWork = Substitute.For<UnitOfWork>(new object[] { null });
            unitOfWork.GetRepository<IUserRepository>().IsUserExist(login)
                .Returns(true);
            boardService = new BoardService(unitOfWork);
            // act
            var result = boardService.VerifyUserLoginExist(login);
            // assert
            Assert.IsTrue(result);
        }

        [Test, AutoData]
        public void RegisterNewUser_Should_Return_NewlyCreatedUser_If_NoUserWithSuchLoginExists(string login, string password)
        {
            // arrange
            unitOfWork = Substitute.For<UnitOfWork>(new object[] { null });
            unitOfWork.GetGenericRepository<IUserRepository, DAL.Model.User>()
                .Returns(Substitute.For<IRepository<DAL.Model.User>>());
            var userRepo = unitOfWork.GetRepository<IUserRepository>();

            userRepo.GetByLoginAndPass(login, password)
                .Returns(new DAL.Model.User { Login = login, Password = password });

            boardService = new BoardService(unitOfWork);
            // act
            var user = boardService.RegisterNewUser(login, password);
            // assert
            Assert.AreEqual(login, user.Login);
            Assert.AreEqual(password, user.Password);
        }

        [Test]
        public void GetRubrics_Should_Return_AllRubrics()
        {
            // arrange
            var fixture = new Fixture();
            List<DAL.Model.Rubric> rubrics = new List<DAL.Model.Rubric>()
            {
                new DAL.Model.Rubric { RubricName = "first" },
                new DAL.Model.Rubric { RubricName = "second" },
                new DAL.Model.Rubric { RubricName = "third" }
            };

            unitOfWork = Substitute.For<UnitOfWork>(new object[] { null });
            unitOfWork.GetGenericRepository<RubricRepository, DAL.Model.Rubric>()
                .Returns(Substitute.For<IRepository<DAL.Model.Rubric>>()
                );

            var userRepo = unitOfWork.GetRepository<IUserRepository>();
            var genericUserRepository = unitOfWork.GetGenericRepository<RubricRepository, DAL.Model.Rubric>();
            genericUserRepository.Get().Returns(rubrics);

            boardService = new BoardService(unitOfWork);
            // act
            var rubricsResult = boardService.GetRubrics();
            // assert
            Assert.IsTrue(rubricsResult.Count == rubrics.Count);
        }
    }
}
