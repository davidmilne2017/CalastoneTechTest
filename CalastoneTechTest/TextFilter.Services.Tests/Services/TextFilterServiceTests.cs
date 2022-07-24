using TextFilter.Common.Interfaces.FileRepositories;
using TextFilter.Common.Interfaces.Services.Outputters;
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
            var outputterMock = new Mock<IOutputter>();
            var sut = new TextFilter.Services.Services.TextFilter(strategies, fileReaderMock.Object, outputterMock.Object);
            
            //Act
            await sut.FilterText("");

            //Assert
            fileReaderMock.Verify(x => x.ReadFileAsync(It.IsAny<string>()), Times.Never);
            fileReaderMock.Verify(x => x.GetDefaultText(), Times.Once);
            strategyMock.Verify(x => x.FilterText(It.IsAny<string>()), Times.Exactly(strategies.Length));
            outputterMock.Verify(x => x.OutputText(It.IsAny<string>()), Times.Once);

        }

        [Fact]
        public async Task FilterText_NonBlankString_CallsCorrectRoutine()
        {

            //Arrange
            var fileReaderMock = new Mock<IFileReader>();
            var strategyMock = new Mock<ITextFilterStrategy>();
            var strategies = new[] { strategyMock.Object, strategyMock.Object };
            var outputterMock = new Mock<IOutputter>();
            var sut = new TextFilter.Services.Services.TextFilter(strategies, fileReaderMock.Object, outputterMock.Object);

            var filename = "fileName";
            
            //Act
            await sut.FilterText(filename);

            //Assert
            fileReaderMock.Verify(x => x.ReadFileAsync(filename), Times.Once);
            fileReaderMock.Verify(x => x.GetDefaultText(), Times.Never);
            strategyMock.Verify(x => x.FilterText(It.IsAny<string>()), Times.Exactly(strategies.Length));
            outputterMock.Verify(x => x.OutputText(It.IsAny<string>()), Times.Once);

        }
    }
}
