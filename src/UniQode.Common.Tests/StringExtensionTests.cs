using UniQode.Common.Extensions;
using Xunit;

namespace UniQode.Common.Tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void SanitizeTitle_WithSpecialChars_ShouldBeSanitized()
        {
            // Arrange
            var actual = "Hej hej hallå!~*'.,";
            var expected = "hej-hej-hall";

            // Act
            actual = actual.SanitizeTitle();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}