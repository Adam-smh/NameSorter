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
        public void Sorting_FileNotFound_DisplayErrorMessage()
        {
            // Arrange
            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(fr => fr.ReadFile(It.IsAny<string>())).Returns(new List<string>());
            var sortingNameP = new SortingNameP(mockFileReader.Object, null, null);

            var originalOut = Console.Out;
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            sortingNameP.Run("nonexistentfile.txt");

            // Assert
            Assert.Contains("File does not exist.", writer.ToString());

            // Reset console output
            Console.SetOut(originalOut);
        }

        [Fact]
        public void Sorting_InvalidFileExt_DisplayErrorMessage()
        {
            // Arrange
            var mockFileReader = new Mock<IFileReader>();
            var sortingNameP = new SortingNameP(mockFileReader.Object, null, null);

            var originalOut = Console.Out;
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            sortingNameP.Run("fileName.md");

            // Assert
            Assert.Contains("Invalid file. Please provide a valid .txt file.", writer.ToString());

            // Reset console output
            Console.SetOut(originalOut);


        }

        [Fact]
        public void ReadNamesFromFile_FileExists_ReturnsNamesList()
        {
            // Arrange
            var mockFileReader = new Mock<IFileReader>();
            var expectedNames = new List<string> { "John Doe", "Jane Smith", "Alex Johnson" };
            mockFileReader.Setup(fr => fr.ReadFile(It.IsAny<string>())).Returns(expectedNames);

            var sortingNameP = new SortingNameP(mockFileReader.Object, null, null);

            // Act
            var result = sortingNameP.Run("testFile.txt");

            // Assert
            Assert.Equal(expectedNames, result);
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
            mockFileReader.Setup(fr => fr.ReadFile(inputFilePath)).Returns(expectedSortedNames);
            mockNameSorter.Setup(ns => ns.SortNames(unsortedNames)).Returns(expectedSortedNames);

            var sortingNameP = new SortingNameP(mockFileReader.Object, new NameSorter(), null);

            // Act
            var result = sortingNameP.Run(inputFilePath, outputFilePath);

            // Assert
            Assert.Equal(expectedSortedNames, result);
        }
    }
}