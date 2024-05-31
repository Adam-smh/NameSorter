# Name Sorter Application

## Description
This console application reads a list of names from a file, sorts them by last name, <br/>
middle names and first name and writes the sorted list to a new file.

## Prerequisites
- .NET 7.0 SDK installed

## Getting Started
### Cloning the Repository
1. Clone the repository:
    ```sh
    git clone https://github.com/Adam-smh/NameSorter.git
    cd NameSorterApp
    ```

### Building the Project
2. Build the project:
    ```sh
    dotnet build
    ```

### Running the Application
3. Run the application with the input file path as an argument:
    ```sh
    dotnet run --project NameSorterApp.csproj <YourFile.txt>
    ```
    (Ensure that your file is a .txt file and includes a list of names)

4. Follow the prompts on the console to provide the output file name.

### Running Unit Tests
To run the unit tests, navigate to the testing folder:
```sh
cd NameSorterApp.UnitTests
```

Execute the following command:
```sh
dotnet test
```
Tests include:

- Sorting_FileNotFound_DisplayErrorMessage() - Testing response to nonexisting file
- Sorting_InvalidFileExt_DisplayErrorMessage() - Testing response to incorrect file extention being used
- ReadNamesFromFile_FileExists_ReturnsNamesList() - Testing reading names from file and pushing to a list
- SortNames_UnsortedList_ReturnsSortedList() - Testing name sorting function
