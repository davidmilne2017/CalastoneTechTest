using Microsoft.Extensions.Logging;
using TextFilter.Infrastructure.FileRepositories;

namespace TextFilter.Infrastructure.Tests.FileRepositories
{
    public class FileReadTests
    {

        private const string FilePathError = "path (Parameter '{0}')";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task ReadFileAsync_NoOrNullPath_ThrowsError(string path)
        {
            //Arrange
            var loggerMock = new Mock<ILogger<FileReader>>();
            var sut = new FileReader(loggerMock.Object);

            //Act/Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () => await sut.ReadFileAsync(path));
            ex.Message.Should().Be(string.Format(FilePathError, FileReader.NoPathProvidedError));

        }
    }
}
