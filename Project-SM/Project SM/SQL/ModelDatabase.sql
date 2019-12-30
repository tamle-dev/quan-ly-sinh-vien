CREATE DATABASE Univer
Go
USE Univer
CREATE TABLE Classes
(
	ClassID varchar(10) PRIMARY KEY NOT NULL
);
CREATE TABLE Students
(
	StudentID varchar(10) PRIMARY KEY NOT NULL,
	FullName nvarchar(255) NOT NULL,
	Gender nvarchar(255) ,
	ID varchar(255) UNIQUE NOT NULL,
	ClassID varchar(10)
);
CREATE TABLE Courses
(
	CourseID varchar(10) PRIMARY KEY NOT NULL,
	CourseName nvarchar(255),
	Room varchar(10),
	ClassID varchar(10)
)
CREATE TABLE ClassCourses
(
	CourseID varchar(10) NOT NULL,
	StudentID varchar(10) NOT NULL
	PRIMARY KEY(CourseID,StudentID)
);
CREATE TABLE GradeCourses
(
	CourseID varchar(10) NOT NULL,
	StudentID varchar(10) NOT NULL,
	GradeGK float,
	GradeCK float,
	GradeE float,
	Total float
	PRIMARY KEY(CourseID,StudentID)
);

CREATE TABLE Account
(
	ID varchar(255) NOT NULL PRIMARY KEY,
	Pass varchar(255) NOT NULL
);

ALTER TABLE Courses
	ADD CONSTRAINT CI_to_CI FOREIGN KEY (ClassID) REFERENCES Classes(ClassID);
ALTER TABLE Students
	ADD CONSTRAINT SC_to_CC FOREIGN KEY (ClassID) REFERENCES Classes(ClassID);
ALTER TABLE ClassCourses
	ADD CONSTRAINT CourseID_to_courseID FOREIGN KEY (CourseID) REFERENCES Courses(CourseID);
ALTER TABLE ClassCourses
	ADD CONSTRAINT SI_to_SI FOREIGN KEY (StudentID) REFERENCES Students(StudentID);
ALTER TABLE GradeCourses
	ADD CONSTRAINT CID_to_cID FOREIGN KEY (CourseID) REFERENCES Courses(CourseID);
ALTER TABLE GradeCourses
	ADD CONSTRAINT StI_to_StI FOREIGN KEY (StudentID) REFERENCES Students(StudentID);

SELECT * FROM Classes
SELECT * FROM Students
SELECT * FROM Courses
SELECT * FROM ClassCourses
SELECT * FROM GradeCourses
SELECT * FROM Account


use master
DROP DATABASE Univer