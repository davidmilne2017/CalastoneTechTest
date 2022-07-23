using TextFilter.Services.Services.Strategies;

namespace TextFilter.Services.Tests.Services.Strategies
{
    public class FilterWordsWithTTests
    {
        [Fact]
        public void FilterWordWithT_ReturnsCorrectly()
        {
            //Arrange
            var sut = new FilterWordsWithT();
            var text = "down to a Tee";
            var exp = "down a";

            //Act
            var result = sut.FilterText(text);

            //Assert
            result.Should().Be(exp);
        }
    }
}
