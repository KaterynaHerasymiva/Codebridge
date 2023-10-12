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
        public void TestSortingByNameDescending()
        {
            var sortingByNameDefault = new SortPaginationModel
            {
                Attribute = nameof(Dog.Name),
                Order = SortingOrder.Desc
            };

            var dogs = _dogsServiece.GetAllDogs(sortingByNameDefault);
            var dogFromRepo = _dogsTestRepo.GetDogs().OrderByDescending(t => t.Name).ToArray();

            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }

        }

        [Test]
        public void TestSortingByColor()
        {
            var sortingByColorDefault = new SortPaginationModel
            {
                Attribute = nameof(Dog.Color),
            };

            var dogs = _dogsServiece.GetAllDogs(sortingByColorDefault);
            var dogFromRepo = _dogsTestRepo.GetDogs().OrderBy(t => t.Color).ToArray();

            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }

        }

        [Test]
        public void TestSortingByTailLength()
        {
            var sortingByTailLengthDefault = new SortPaginationModel
            {
                Attribute = nameof(Dog.TailLength),
            };

            var dogs = _dogsServiece.GetAllDogs(sortingByTailLengthDefault);
            var dogFromRepo = _dogsTestRepo.GetDogs().OrderBy(t => t.TailLength).ToArray();

            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }
        }

        [Test]
        public void TestSortingByWeight()
        {
            var sortingByWeightDefault = new SortPaginationModel
            {
                Attribute = nameof(Dog.Weight),
            };

            var dogs = _dogsServiece.GetAllDogs(sortingByWeightDefault);
            var dogFromRepo = _dogsTestRepo.GetDogs().OrderBy(t => t.Weight).ToArray();

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
            var sortingByColorWithPagination = new SortPaginationModel
            {
                Attribute = nameof(Dog.Color),
                Order = SortingOrder.Desc,
                PageNumber = 2,
                PageSize = 2
            };

            // Act
            var dogs = _dogsServiece.GetAllDogs(sortingByColorWithPagination);
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
            var paginationModel = new SortPaginationModel
            {
                PageNumber = 4,
                PageSize = 1
            };

            // Act
            var dogs = _dogsServiece.GetAllDogs(paginationModel);
            var dogFromRepo = _dogsTestRepo.GetDogs().Skip(3).Take(1).ToArray();

            // Assert
            int i = 0;
            foreach (var dog in dogs)
            {
                var dogFormRepo = dogFromRepo[i++];
                Assert.That(dogFormRepo, Is.SameAs(dog));
            }
        }

        [Test]
        public void TestPaginationInvalidPageNumber()
        {
            // Arrange
            var paginationModel = new SortPaginationModel
            {
                PageNumber = -4,
                PageSize = 1
            };

            var ex = Assert.Throws<ArgumentException>(() => _dogsServiece.GetAllDogs(paginationModel));

            Assert.That(ex.Message, Is.EqualTo(nameof(SortPaginationModel.PageNumber)));
        }

        [Test]
        public void TestPaginationInvalidPageSize()
        {
            // Arrange
            var paginationModel = new SortPaginationModel
            {
                PageNumber = 2,
                PageSize = -1
            };

            var ex = Assert.Throws<ArgumentException>(() => _dogsServiece.GetAllDogs(paginationModel));

            Assert.That(ex.Message, Is.EqualTo(nameof(SortPaginationModel.PageSize)));
        }

        [Test]
        public async Task TestAddDog()
        {
            var dog = new Dog()
            {
                Name = "Kuzma",
                Color = "brown",
                TailLength = 17,
                Weight = 20
            };

            var addedDog = await _dogsServiece.AddDogAsync(dog);
            Assert.That(dog, Is.EqualTo(addedDog));
        }

        [Test]
        public void TestAddNullDog()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _dogsServiece.AddDogAsync(null));

        }
    }
}