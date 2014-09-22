DROP DATABASE IF EXISTS BooksDB;

CREATE DATABASE BooksDB;

USE BooksDB;

CREATE TABLE Books(
  BookID INT NOT NULL AUTO_INCREMENT,
  Title VARCHAR(45) NOT NULL,
  Author VARCHAR(45) NOT NULL,
  PublishDate DATE NOT NULL,
  ISBN VARCHAR(45) NOT NULL,
  PRIMARY KEY (BookID)
) ENGINE = InnoDB;

INSERT INTO Books(Title, Author, PublishDate, ISBN)
VALUES ('The lions', 'Leonid Garfield', '2012-01-01', '1234567891014');

INSERT INTO Books(Title, Author, PublishDate, ISBN)
VALUES ('The tigers', 'George Nakov', '1998-04-01', '0254563891011');

INSERT INTO Books(Title, Author, PublishDate, ISBN)
VALUES ('Aligators attacking people', 'Petko Milev', '1888-12-10', '0234156151014');

INSERT INTO Books(Title, Author, PublishDate, ISBN)
VALUES ('Birds cannot really fly', 'Trendafil Trendafilov', '2014-08-27', '1234567891011');

INSERT INTO Books(Title, Author, PublishDate, ISBN)
VALUES ('How does the ponguin walk?', 'Teofanios Gekas', '1999-11-05', '1234367891014');