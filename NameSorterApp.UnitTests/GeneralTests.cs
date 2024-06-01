using Xunit;
using System;
using NameSorterApp.Interfaces;
using Moq;
using System.IO;
using NameSorterApp.Implementations;

namespace NameSorterApp.UnitTests
{
    public class GeneralTests
    {
        [Fact]
        public void ReadFile_FileNotFound_ReturnsEmptyList()
        {
            // Arrange
            var fileReader = new FileReader();
            var filePath = "nonExistentFile.txt";

            // Act
            var result = fileReader.ReadFile(filePath);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReadFile_InvalidFileExtension_ReturnsNull()
        {
            // Arrange
            var fileReader = new FileReader();
            var filePath = "fileName.md";

            // Act
            var result = fileReader.ReadFile(filePath);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadFile_FileExists_ReturnsNamesList()
        {
            // Arrange
            // Arrange
            var fileReader = new FileReader();
            var filePath = "testFile.txt";
            var expectedContent = new List<string> { "John Doe", "Jane Smith", "Alex Johnson" };
            File.WriteAllLines(filePath, expectedContent);

            // Act
            var result = fileReader.ReadFile(filePath);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedContent, result);

            // Cleanup
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [Fact]
        public void SortNames_UnsortedList_ReturnsSortedList()
        {
            // Arrange
            var inputFilePath = "testFile.txt";
            var outputFilePath = "testedFile.txt";

            var mockNameSorter = new Mock<INameSorter>();
            var mockFileReader = new Mock<IFileReader>();

            var unsortedNames = new List<string> { "John Doe", "Jane Smith", "Alex Johnson" };
            var expectedSortedNames = new List<string> { "John Doe", "Alex Johnson", "Jane Smith" };
            mockFileReader.Setup(fr => fr.ReadFile(inputFilePath)).Returns(unsortedNames);
            mockNameSorter.Setup(ns => ns.SortNames(unsortedNames)).Returns(expectedSortedNames);

            var sortingNameP = new SortingNameP(mockFileReader.Object, new NameSorter(), null);

            // Act
            var result = sortingNameP.Run(inputFilePath, outputFilePath);

            // Assert
            Assert.Equal(expectedSortedNames, result);
        }

        [Fact]
        public void WriteFile_ValidPathAndContent_FileIsWritten()
        {
            // Arrange
            var fileWriter = new FileWriter();
            var filePath = "testedFile.txt";
            var content = new List<string> { "Alex Johnson", "John Doe", "Jane Smith" };

            // Act
            fileWriter.WriteFile(filePath, content);

            // Assert
            Assert.True(File.Exists(filePath));
            var writtenContent = File.ReadAllLines(filePath);
            Assert.Equal(content, writtenContent);

            // Cleanup
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}