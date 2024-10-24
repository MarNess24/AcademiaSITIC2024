if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Enrollments].[Get]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Enrollments].[Get]
END
GO
CREATE PROCEDURE [Enrollments].[Get]
	@EnrollmentId	  INT
AS
BEGIN
	SELECT EnrollmentId, StudentId, CourseId, EnrollmentDate
	FROM Enrollments
	WHERE EnrollmentId = @EnrollmentId
END
GO
EXEC sp_recompile N'[Enrollments].[Get]'