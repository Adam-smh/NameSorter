using Xunit;
using System;

namespace NameSorterApp.UnitTests
{
    public class GeneralTests
    {
        [Fact]
        public void Sorting_FileNotFound_DisplayErrorMessage()
        {
            // Arrange
            var originalOut = Console.Out;
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            SortingNameP.Main(new[] { "nonexistentfile.txt" });

            // Assert
            Assert.Contains("The file nonexistentfile.txt does not exist.", writer.ToString());

            // Reset console output
            Console.SetOut(originalOut);
        }
    }
}