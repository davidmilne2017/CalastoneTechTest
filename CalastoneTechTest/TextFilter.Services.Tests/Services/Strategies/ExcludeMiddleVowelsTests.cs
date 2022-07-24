using Microsoft.Extensions.Logging;
using TextFilter.Services.Services.Strategies;

namespace TextFilter.Services.Tests.Services.Strategies
{
    public class ExcludeMiddleVowelsTests
    {

        [Theory]
        [InlineData("clean rather","rather")]
        [InlineData("lEan the test", "the")]
        public void ExcludeMiddleVowels_ExcludesWordsCorrectly(string text, string exp)
        {
            //Arrange
            var loggerMock = new Mock<ILogger<ExcludeMiddleVowels>>();
            var sut = new ExcludeMiddleVowels(loggerMock.Object);

            //Act
            var result = sut.FilterText(text);

            //Assert
            result.Should().Be(exp);
        }
    }
}
