
# LibraryAPI

This API provides a way to interact with a books and authors collections, including CRUD operations for books and authors, as well as additional functionality for managing the resources.

## Models
### Book
- Id: int
- Title: string
- Description: string
- Rating: float
- ISBN: string
- PublicationDate: DateTime (passed in DateOnly format "yyyy-mm-dd")
- AuthorID: int
- Author: Author (ForeignKey)

### Author
- Id: int
- FirstName: string
- LastName: string
- BirthDate: DateTime (passed in DateOnly format "yyyy-mm-dd")
- Gender: string (converted to bit value)
- Books: ICollection of Book
## Converters
Custom value converters used in project:

- DateOnlyConverter: used to convert between DateOnly and DateTime2

- GenderToNumericConverter: used to convert between string values (male/female) to bit values (0/1) used in database
## Getting started

- To use this API, you will need to have the following installed:
    - .NET Core 3.1 or later
    - An IDE such as Visual Studio or Visual Studio Code

- Clone the repository and open the solution in your IDE
- Use the Package Manager to install following packages:
    - Entity Framework 6
    - Microsoft AspNet Core 6
    - Microsoft AspNet 6
    - Microsoft Entity Framework Core 6
- Use LibraryDB.sql file to create database on your local server instance.
- Run the API using the command dotnet run or IDE interface
- Use a tool such as Postman to interact with the API and perform CRUD operations on the book and author resources.
## Endpoints

| Method | Endpoint     | Description                 |
|--------|--------------|-----------------------------|
| GET    | /api/books   | Retrieve a list of all books |
| GET    | /api/books/{id} | Retrieve a specific book by id |
| GET    | /api/books/ByTitle/{title} | Retrieve a specific book by title |
| GET    | /api/Books/ByAuthor/{authorName} | Retrieve a specific book by id |
| POST   | /api/books   | Create a new book           |
| PUT    | /api/books/{id} | Update an existing book    |
| DELETE | /api/books/{id} | Delete a book             |
| GET    | /api/authors | Retrieve a list of all authors |
| GET    | /api/authors/{id} | Retrieve a specific author by id |
| GET    | /api/authors/ByName/{FullName}| Retrieve a specific author by full name |
| POST   | /api/authors | Create a new author         |

## Note
- All of the packages and dependencies **needs** to installed and configured.
- The database **needs** to be created by using provided SQL file.
- Postman collection **with all endpoints and examples** is provided in repository