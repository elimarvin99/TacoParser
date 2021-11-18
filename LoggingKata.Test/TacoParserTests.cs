using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // This method gets long and lat for a taco bell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);    //checking to see that var actual is not null, it in fact does contain the required information.

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)   //line is taco bell location, double is the longitude expected
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var test = new TacoParser();
            //Act
            var actual = test.Parse(line);
            //Assert
            Assert.Equal(actual.Location.Longitude, expected);     //need to add in method to return string
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var test = new TacoParser();
            //Act
            var actual = test.Parse(line);
            //Assert
            Assert.Equal(actual.Location.Latitude, expected);
        }
    }
}
