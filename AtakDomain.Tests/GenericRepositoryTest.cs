using AtakDomain.Common.Entities;
using AtakDomain.Common.Intarfaces;
using Moq;

namespace AtakDomain.Tests
{
    public class GenericRepositoryTest
    {
        private readonly Category testObject1;
        private readonly Category testObject2;
        private readonly Category testObject3;
        private readonly List<Category> testList;

        public GenericRepositoryTest()
        {
            testObject1 = new Category("cat-1", "cat-1-name");
            testObject2 = new Category("cat-2", "cat-2-name");
            testObject3 = new Category("cat-3", "cat-3-name");
            testList = new List<Category>()
                {
                    testObject1,
                    testObject2,
                };
        }

        [Fact]
        public async Task GetAll_ShouldReturn_AllItemsAsync()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepositoryAsync<Category>>();
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(testList);
            var repository = mockRepository.Object;

            // Act
            var expected = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(expected);
            Assert.True(expected.Count() == 2);
        }

        [Fact]
        public async Task GetById_ShouldReturn_ExpectedItem()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepositoryAsync<Category>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((string a) => testList.Single(x => x.CategoryId == a));
            var repository = mockRepository.Object;

            // Act
            var expected = await repository.GetByIdAsync("cat-1");

            // Assert
            Assert.NotNull(expected);
            Assert.True(expected.CategoryId == "cat-1");
        }

        [Fact]
        public async Task Add_ShouldReturn_AddedItem()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepositoryAsync<Category>>();
            mockRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).ReturnsAsync(testObject3);
            var repository = mockRepository.Object;

            // Act
            var expected = await repository.AddAsync(testObject3);

            // Assert
            Assert.NotNull(expected);
            Assert.Equal(expected.CategoryId, testObject3.CategoryId);
        }

        [Fact]
        public async Task Update_ShouldReturn_UpdatedValue()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepositoryAsync<Category>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Category>())).Callback((Category target) =>
            {
                var origin = testList.Single(x => x.CategoryId == target.CategoryId);
                origin.CategoryName = target.CategoryName;
            });
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((string a) => testList.Single(x => x.CategoryId == a));

            var repository = mockRepository.Object;

            // Act
            var cat = new Category("cat-1", "cat-1-name-updated");
            await repository.UpdateAsync(cat);
            var expected = await repository.GetByIdAsync("cat-1");

            // Assert
            Assert.NotNull(expected);
            Assert.Equal(expected.CategoryName, cat.CategoryName);
        }

        [Fact]
        public async Task Delete_ShouldRetun_Null()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepositoryAsync<Category>>();
            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<Category>())).Callback((Category a) =>
            {
                var origin = testList.Single(x => x.CategoryId == a.CategoryId);
                testList.Remove(origin);
            });
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((string a) => testList.SingleOrDefault(x => x.CategoryId == a));
            var repository = mockRepository.Object;

            // Act
            await repository.DeleteAsync(testObject2);
            var expected = await repository.GetByIdAsync(testObject2.CategoryId);

            // Assert
            Assert.Null(expected);
        }
    }
}