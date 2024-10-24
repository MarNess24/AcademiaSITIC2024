if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Courses].[Insert]') AND
		    TYPE in (N'P', N'PC'))

BEGIN
	DROP PROCEDURE [Courses].[Insert]
END
GO
CREATE PROCEDURE [Courses].[Insert]
	@Name	   VARCHAR(150),
	@Credits   INT,
	@CourseId  INT OUT
-- WITH ENCRYPTION
AS
BEGIN
	INSERT INTO Courses(Name, Credits) VALUES(@Name, @Credits)
	SET @CourseId = SCOPE_IDENTITY()
END
GO
EXEC sp_recompile N'[Courses].[Insert]'