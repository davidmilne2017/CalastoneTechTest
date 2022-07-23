using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFilter.Services.Services.Strategies;

namespace TextFilter.Services.Tests.Services.Strategies
{
    public class FilterWordsLessThenThreeTests
    {

        [Fact]
        public void FilterWordsLessThanThree_ReturnsCorrectly()
        {
            //Arrange
            var sut = new FilterWordsLessThanThree();
            var text = "down to a tee";
            var exp = "down tee";

            //Act
            var result = sut.FilterText(text);

            //Assert
            result.Should().Be(exp);
        }
    }
}
