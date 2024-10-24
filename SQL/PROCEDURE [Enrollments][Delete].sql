if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Enrollments].[Delete]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Enrollments].[Delete]
END
GO
CREATE PROCEDURE [Enrollments].[Delete]
	@EnrollmentId	  INT
AS
BEGIN
	DELETE Enrollments
	WHERE EnrollmentId = @EnrollmentId
END
GO
EXEC sp_recompile N'[Enrollments].[Delete]'