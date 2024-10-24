if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Enrollments].[GetAll]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Enrollments].[GetAll]
END
GO
CREATE PROCEDURE [Enrollments].[GetAll]
AS
BEGIN
	SELECT EnrollmentId, StudentId, CourseId, EnrollmentDate
	FROM Enrollments
END
GO
EXEC sp_recompile N'[Enrollments].[GetAll]'