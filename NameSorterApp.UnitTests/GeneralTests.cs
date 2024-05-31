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
            SortingNameP.readFile("nonexistentfile.txt");

            // Assert
            Assert.Contains("file does not exist", writer.ToString());

            // Reset console output
            Console.SetOut(originalOut);
        }

        [Fact]
        public void Sorting_InvalidFileExt_DisplayErrorMessage()
        {
            // Arrange
            var originalOut = Console.Out;
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            SortingNameP.Main(new[] { "fileName.md" });

            // Assert
            Assert.Contains("file is invalid, please only insert .txt files", writer.ToString());

            // Reset console output
            Console.SetOut(originalOut);
        }

        [Fact]
        public void ReadNamesFromFile_FileExists_ReturnsNamesList()
        {
            // Arrange
            var filePath = "testfile.txt";
            var expectedNames = new List<string> { "John Doe", "Jane Smith" };
            File.WriteAllLines(filePath, expectedNames);

            // Act
            var result = SortingNameP.readFile(filePath);

            // Assert
            Assert.Equal(expectedNames, result);

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void SortNames_UnsortedList_ReturnsSortedList()
        {
            // Arrange
            var unsortedNames = new List<string> { "John Doe", "Jane Smith", "Alex Johnson" };
            var expectedSortedNames = new List<string> { "John Doe", "Alex Johnson", "Jane Smith" };

            // Act
            var res = SortingNameP.SortNames(unsortedNames);

            // Assert
            Assert.Equal(expectedSortedNames, res);
        }

    }
}