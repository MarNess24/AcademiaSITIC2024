CREATE DATABASE Excercises;
USE Excercises;

/*CREATE TABLE [User] 
(
	UserId INT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(50) NOT NULL,
	Password VARCHAR(50) NOT NULL
)*/

-- Error de si ya existe la tabla
IF NOT EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Students]') AND OBJECTPROPERTY(id, N'isUserTable') = 1)
BEGIN
	CREATE TABLE Students
	(
		StudentId   INT NOT NULL PRIMARY KEY IDENTITY(1,1),
		Name        VARCHAR(150) NOT NULL,
		DateOfBirth DATE NOT NULL,
		Email		VARCHAR(100) -- NULL
	)
END

-- Error de si ya existe la tabla
IF NOT EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Students]') AND OBJECTPROPERTY(id, N'isUserTable') = 1)
BEGIN
CREATE TABLE Courses
	(
		CourseId INT PRIMARY KEY IDENTITY(1,1),
		Name VARCHAR(100),
		Credits INT
	)
END

-- Error de si ya existe la tabla
IF NOT EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Students]') AND OBJECTPROPERTY(id, N'isUserTable') = 1)
BEGIN
	CREATE TABLE Enrollments
	(
		EnrollmentId   INT PRIMARY KEY IDENTITY(1,1),
		StudentId  	   INT, 
		CourseId	   INT,
		EnrollmentDate DATE NOT NULL,
		FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
		FOREIGN KEY (CourseId)  REFERENCES Courses(CourseId)
	)
END

SELECT * FROM Students
SELECT * FROM Courses
SELECT * FROM Enrollments