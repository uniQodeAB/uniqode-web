using UniQode.Common.Utils;
using Xunit;

namespace UniQode.Common.Tests
{
    public class PasswordHashTests
    {
        private readonly string _plainText = "S3cret123!!";

        [Fact]
        public void Create_GivenPlainText_ShouldSucceed()
        {
            // Arrange
            var plainText = _plainText;

            // Act
            var hash = PasswordHash.Create(plainText);

            // Assert
            Assert.NotNull(hash);
            Assert.NotEmpty(hash);
        }

        [Fact]
        public void Create_GivenPlainText_ShouldNotBeLongerThan200()
        {
            // Arrange
            var plainText = _plainText;

            // Act
            var hash = PasswordHash.Create(plainText);

            // Assert
            Assert.NotNull(hash);
            Assert.NotEmpty(hash);
            Assert.False(hash.Length > 200);
        }

        [Fact]
        public void CreateAndVerify_GivenPlainText_ShouldSucceed()
        {
            // Arrange
            var password = _plainText;

            // Act
            var hash = PasswordHash.Create(password);
            var match = PasswordHash.VerifyPassword(password, hash);

            // Assert
            Assert.True(match);
        } 
    }
}