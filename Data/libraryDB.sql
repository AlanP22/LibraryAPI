CREATE DATABASE [Books and Authors db];

Create table [Books and Authors db].dbo.Book (
Id int Primary Key IDENTITY(1,1) Not Null,
Title NVARCHAR(100) Not Null,
Description NVARCHAR(MAX) Not Null,
Rating decimal Not Null,
ISBN NVARCHAR(13) Not Null,
PublicationDate Datetime2 Not Null);

Create table [Books and Authors db].dbo.Author (
Id int Primary Key IDENTITY(1,1) Not Null,
FirstName NVARCHAR(50) Not Null,
LastName NVARCHAR(50) Not Null,
BirthDate Datetime2 Not Null,
Gender bit Not Null);

Create table [Books and Authors db].dbo.BookAuthor (
BookId int Foreign Key REFERENCES [Books and Authors db].dbo.Book Not Null,
AuthorId int Foreign Key REFERENCES [Books and Authors db].dbo.Author Not Null);