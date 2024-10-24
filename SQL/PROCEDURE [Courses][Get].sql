if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Courses].[Get]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Courses].[Get]
END
GO
CREATE PROCEDURE [Courses].[Get]
	@CourseId	  INT
AS
BEGIN
	SELECT CourseId, Name, Credits
	FROM Courses
	WHERE CourseId = @CourseId
END
GO
EXEC sp_recompile N'[Courses].[Get]'