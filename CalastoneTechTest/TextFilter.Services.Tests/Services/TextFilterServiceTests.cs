using TextFilter.Common.Interfaces.FileRepositories;
using TextFilter.Common.Interfaces.Services.Strategies;

namespace TextFilter.Services.Tests.Services
{
    public class TextFilterServiceTests
    {
        [Fact]
        public async Task FilterText_BlankString_CallsCorrectRoutine()
        {

            //Arrange
            var fileReaderMock = new Mock<IFileReader>();
            var strategyMock = new Mock<ITextFilterStrategy>();
            var strategies = new[] { strategyMock.Object, strategyMock.Object };
            var sut = new TextFilter.Services.Services.TextFilter(strategies, fileReaderMock.Object);
            
            var exp = "result";
            strategyMock.Setup(x => x.FilterText(It.IsAny<string>())).Returns(exp);

            //Act
            var result = await sut.FilterText("");

            //Assert
            result.Should().Be(exp);
            fileReaderMock.Verify(x => x.ReadFileAsync(It.IsAny<string>()), Times.Never);
            fileReaderMock.Verify(x => x.GetDefaultText(), Times.Once);
            strategyMock.Verify(x => x.FilterText(It.IsAny<string>()), Times.Exactly(strategies.Length));

        }

        [Fact]
        public async Task FilterText_NonBlankString_CallsCorrectRoutine()
        {

            //Arrange
            var fileReaderMock = new Mock<IFileReader>();
            var strategyMock = new Mock<ITextFilterStrategy>();
            var strategies = new[] { strategyMock.Object, strategyMock.Object };
            var sut = new TextFilter.Services.Services.TextFilter(strategies, fileReaderMock.Object);

            var filename = "fileName";
            var exp = "result";
            strategyMock.Setup(x => x.FilterText(It.IsAny<string>())).Returns(exp);

            //Act
            var result = await sut.FilterText(filename);

            //Assert
            result.Should().Be(exp);
            fileReaderMock.Verify(x => x.ReadFileAsync(filename), Times.Once);
            fileReaderMock.Verify(x => x.GetDefaultText(), Times.Never);
            strategyMock.Verify(x => x.FilterText(It.IsAny<string>()), Times.Exactly(strategies.Length));

        }
    }
}
