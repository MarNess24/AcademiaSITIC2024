if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Enrollments].[Insert]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Enrollments].[Insert]
END
GO
CREATE PROCEDURE [Enrollments].[Insert]
	@StudentId		  INT,
	@CourseId		  INT,
	@EnrollmentDate   DATE,
	@EnrollmentId	  INT OUT
--WITH ENCRYPTION 
AS
BEGIN
	INSERT INTO Enrollments(StudentId, CourseId, EnrollmentDate) VALUES (@StudentId, @CourseId, @EnrollmentDate)
	SET @EnrollmentId = SCOPE_IDENTITY()
END
GO
EXEC sp_recompile N'[Enrollments].[Insert]'