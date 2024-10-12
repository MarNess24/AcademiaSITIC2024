DECLARE @StudentId INT,
		@CourseId INT,
		@EnrollmentId INT

EXEC [Students].[Insert]'Maria Villaseñor', '19950707', 'maria.villase@siticsoftware.com', @StudentId OUTPUT

SELECT @StudentId

EXEC [Courses].[Insert] 'SITIC', 100, @CourseId OUTPUT

DECLARE @EnrollmentId INT
EXECUTE Enrollments.[Insert] '1', '1', '20240510' ,@EnrollmentId OUTPUT




