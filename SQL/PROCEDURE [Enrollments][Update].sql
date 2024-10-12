if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Enrollments].[Update]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Enrollments].[Update]
END
GO
CREATE PROCEDURE [Enrollments].[Update]
	@EnrollmentId	INT,
	@StudentId		INT,
	@CourseId		INT,
	@EnrollmentDate	DATE
AS
BEGIN
	UPDATE Enrollments 
	SET StudentId = @StudentId,
		CourseId = @CourseId,
		EnrollmentDate = @EnrollmentDate
	WHERE EnrollmentId = @EnrollmentId
END
GO
EXEC sp_recompile N'[Enrollments].[Update]'