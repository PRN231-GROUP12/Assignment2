-- Tạo database
CREATE DATABASE BookPublishingDB;
GO

USE BookPublishingDB;
GO

-- Tạo bảng Publisher
CREATE TABLE Publisher (
    PublisherId INT PRIMARY KEY IDENTITY(1,1),
    PublisherName VARCHAR(100) NOT NULL,
    City VARCHAR(50) NOT NULL,
    State VARCHAR(50) NOT NULL,
    Country VARCHAR(50) NOT NULL
);

-- Tạo bảng Role
CREATE TABLE Role (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleDesc VARCHAR(100) NOT NULL
);

-- Tạo bảng Author
CREATE TABLE Author (
    AuthorId INT PRIMARY KEY IDENTITY(1,1),
    LastName VARCHAR(50) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    Phone VARCHAR(20),
    Address VARCHAR(200),
    City VARCHAR(50),
    State VARCHAR(50),
    Zip VARCHAR(10),
    EmailAddress VARCHAR(100)
);

-- Tạo bảng Book
CREATE TABLE Book (
    BookId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    PublisherId INT FOREIGN KEY REFERENCES Publisher(PublisherId),
    Price DECIMAL(10,2) NOT NULL,
    Advance DECIMAL(10,2),
    Royalty DECIMAL(5,2),
    YtdSales INT,
    Notes VARCHAR(MAX),
    PublishedDate DATE
);

-- Tạo bảng User
CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    EmailAddress VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Source VARCHAR(50),
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    LastName VARCHAR(50) NOT NULL,
    RoleId INT FOREIGN KEY REFERENCES Role(RoleId),
    PublisherId INT FOREIGN KEY REFERENCES Publisher(PublisherId),
    HireDate DATE
);

-- Tạo bảng BookAuthor
CREATE TABLE BookAuthor (
    AuthorId INT FOREIGN KEY REFERENCES Author(AuthorId),
    BookId INT FOREIGN KEY REFERENCES Book(BookId),
    AuthorOrder INT,
    RoyalityPercentage DECIMAL(5,2),
    PRIMARY KEY (AuthorId, BookId)
);