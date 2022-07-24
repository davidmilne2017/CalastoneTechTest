using TextFilter.Common.Extensions;

namespace TextFilter.Common.Tests.Extensions
{
    public class StringExtensionsTests
    {
        public const string TestText = @"Hello, I'm a developer writing a technical test, Does my string-split work as expected? Let's find out.

Success?

or Failure!";

        [Fact]
        public void StringToWords_SplitsCorrectly()
        {
            //Arrange
            var expected = new string[] { "Hello", "I", "m", "a", "developer", "writing", "a", "technical", "test", "Does", "my", "string", "split", "work", "as", "expected", "Let","s", "find", "out", "Success", "or", "Failure" };

            //Act
            var result = TestText.StringToWords().ToArray();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("lEan", "Ea")]
        [InlineData("the", "h")]
        public void MiddleLetters_ReturnsCorrectly(string word, string exp)
        {
            //Arrange/Act
            var result = word.MiddleLetters();

            //Assert
            result.Should().Be(exp);

        }

        [Fact]
        public void CleanSpaces_ReturnsCorrectly()
        {
            //Arrange
            var text = " hello     goodbye ";
            var exp = "hello goodbye";

            //Act
            var result = text.CleanSpaces();

            //Assert
            result.Should().Be(exp);
        }

        [Fact]
        public void ReplaceWord_ReplacesCorrectly()
        {
            //Arrange
            var text = @"it, written. It
smitten it.";
            var exp = @", written. It
smitten .";

            //Act
            var result = text.RemoveWord("it");

            //Assert
            result.Should().Be(exp);

        }
    }
}
