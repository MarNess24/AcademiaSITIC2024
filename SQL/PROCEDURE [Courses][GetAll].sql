if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Courses].[GetAll]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Courses].[GetAll]
END
GO
CREATE PROCEDURE [Courses].[GetAll]
AS
BEGIN
	SELECT CourseId, Name, Credits
	FROM Courses
END
GO
EXEC sp_recompile N'[Courses].[GetAll]'