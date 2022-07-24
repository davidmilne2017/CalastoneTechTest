using Microsoft.Extensions.Logging;
using TextFilter.Services.Services.Strategies;

namespace TextFilter.Services.Tests.Services.Strategies
{
    public class FilterWordsLessThenThreeTests
    {

        [Fact]
        public void FilterWordsLessThanThree_ReturnsCorrectly()
        {
            //Arrange
            var loggerMock = new Mock<ILogger<FilterWordsLessThanThree>>();
            var sut = new FilterWordsLessThanThree(loggerMock.Object);
            var text = "down to a tee";
            var exp = "down tee";

            //Act
            var result = sut.FilterText(text);

            //Assert
            result.Should().Be(exp);
        }
    }
}
