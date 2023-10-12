using Codebridge.BLL;
using Codebridge.BLL.Entities;
using Codebridge.BLL.Services;
using Codebridge.WebApi.Model;
using Microsoft.Extensions.Options;
using Sieve.Models;

namespace Codebridge.Tests
{
    public class DogsServiceTests
    {
        private readonly IDogsService _dogsServiece;
        private readonly DogsTestRepository _dogsTestRepo;

        public DogsServiceTests()
        {
            _dogsTestRepo = new DogsTestRepository();
            _dogsServiece = new DogsService(_dogsTestRepo, new CustomSieveProcessor(Options.Create(new SieveOptions())));
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestWithoutSortingAndPagination()
        {
            var dogs = _dogsServiece.GetAllDogs(new SortPaginationModel());

            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = _dogsTestRepo.GetDogs().ToArray()[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }
        }

        [Test]
        public void TestSortingByNameDefault()
        {
            var sortingByNameDefault = new SortPaginationModel
            {
                Attribute = nameof(Dog.Name)
            };

            var dogs = _dogsServiece.GetAllDogs(sortingByNameDefault);
            var dogFromRepo = _dogsTestRepo.GetDogs().OrderBy(t => t.Name).ToArray();

            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }

        }

        [Test]
        public void TestSortingByInvalidAttribute()
        {
            // Arrange
            var sortingByNameInvalid = new SortPaginationModel
            {
                Attribute = nameof(Dog.Name) + "something",
                Order = SortingOrder.Desc
            };

            // Act
            var dogs = _dogsServiece.GetAllDogs(sortingByNameInvalid);
            var dogFromRepo = _dogsTestRepo.GetDogs().ToArray();

            // Assert
            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }
        }

        [Test]
        public void TestSortingByColorDescWithPagination()
        {
            // Arrange
            var sortingByNameInvalid = new SortPaginationModel
            {
                Attribute = nameof(Dog.Color),
                Order = SortingOrder.Desc,
                PageNumber = 2,
                PageSize = 2
            };

            // Act
            var dogs = _dogsServiece.GetAllDogs(sortingByNameInvalid);
            var dogFromRepo = _dogsTestRepo.GetDogs().OrderByDescending(t => t.Color).Skip(2).Take(2).ToArray();

            // Assert
            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }
        }

        [Test]
        public void TestOnlyPagination()
        {
            // Arrange
            var sortingByNameInvalid = new SortPaginationModel
            {
                PageNumber = 4,
                PageSize = 1
            };

            // Act
            var dogs = _dogsServiece.GetAllDogs(sortingByNameInvalid);
            var dogFromRepo = _dogsTestRepo.GetDogs().Skip(3).Take(1).ToArray();

            // Assert
            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }
        }

        // invalid pagesize and pagenumber check exception
    }
}