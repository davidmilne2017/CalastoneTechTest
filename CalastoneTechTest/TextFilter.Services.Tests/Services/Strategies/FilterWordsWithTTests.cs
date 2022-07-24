using Microsoft.Extensions.Logging;
using TextFilter.Services.Services.Strategies;

namespace TextFilter.Services.Tests.Services.Strategies
{
    public class FilterWordsWithTTests
    {
        [Fact]
        public void FilterWordWithT_ReturnsCorrectly()
        {
            //Arrange
            var loggerMock = new Mock<ILogger<FilterWordsWithT>>();
            var sut = new FilterWordsWithT(loggerMock.Object);
            var text = "down to a Tee";
            var exp = "down a";

            //Act
            var result = sut.FilterText(text);

            //Assert
            result.Should().Be(exp);
        }
    }
}
