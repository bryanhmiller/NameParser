using System;
using NameParser.App;
using Xunit;


namespace NameParser.Tests
{
    public class WhenParsingNameInformation
    {
        [Fact]
        public void OneNameIsEnteredFirstNameIsPopulated()
        {
            // Arrange
            var name = "Zendaya";
            var nameParser = new Parser();
            // Act
            var result = nameParser.ParseName(name);
            // Assert
            Assert.Equal(result.FirstName, "Zendaya");
        }

        [Fact]
        public void TwoNamesAreEnteredFirstAndLastNameArePopulated()
        {
            // Arrange
            var name = "Steve Jones";
            var nameParser = new Parser();
            // Act
            var result = nameParser.ParseName(name);
            // Assert
            Assert.Equal(result.FirstName, "Steve");
            Assert.Equal(result.LastName, "Jones");
        }

        [Fact]
        public void TwoNamesAreEnteredLastNameHyphenatedFirstAndLastNameArePopulated()
        {
            // Arrange
            var name = "Maria Barnes-Jones";
            var nameParser = new Parser();
            // Act
            var result = nameParser.ParseName(name);
            // Assert
            Assert.Equal(result.FirstName, "Maria");
            Assert.Equal(result.LastName, "Barnes-Jones");
        }

        [Fact]
        public void TwoNamesAreEnteredWithAMiddleInitialFollowedByAPeriod()
        {
            // Arrange
            var name = "Steve L. Jones";
            var nameParser = new Parser();
            // Act
            var result = nameParser.ParseName(name);
            // Assert
            Assert.Equal(result.FirstName, "Steve");
            Assert.Equal(result.MiddleName, "L");
            Assert.Equal(result.LastName, "Jones");
        }    
        
        [Fact]
        public void TwoNamesAreEnteredWithASuffixFollowedByAPeriod()
        {
            // Arrange
            var name = "Bob Marley Jr.";
            var nameParser = new Parser();
            // Act
            var result = nameParser.ParseName(name);
            // Assert
            Assert.Equal(result.FirstName, "Bob");
            Assert.Equal(result.LastName, "Marley");
            Assert.Equal(result.Suffix, "Jr.");
        }
        
        [Theory]
        [InlineData("Mr. Bob Michaels", "Mr.", "Bob", "Michaels")]
        [InlineData("Mrs. Aunt Jemima", "Mrs.", "Aunt", "Jemima")]
        public void TwoNamesAreEnterePreceededWithAnHonorificThatIsFollowedByAPeriod(string nameToTest, string expectedHonorific, string expectedFirstName, string expectedLastName)
        {
            // Arrange
            // var name = "Mr. Bob Michaels";
            var nameParser = new Parser();
            // Act
            var result = nameParser.ParseName(nameToTest);
            // Assert
            Assert.Equal(result.Honorific, expectedHonorific);
            Assert.Equal(result.FirstName, expectedFirstName);
            Assert.Equal(result.LastName, expectedLastName);
        }    
    }
}
