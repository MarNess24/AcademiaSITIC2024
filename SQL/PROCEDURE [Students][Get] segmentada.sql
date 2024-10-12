if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Students].[Get]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Students].[Get]
END
GO
CREATE PROCEDURE [Students].[Get]
	@StudentId	  INT
AS
BEGIN
	SELECT StudentId, Name, DateOfBirth, Email
	FROM Students
	WHERE StudentId = @StudentId
END
GO
EXEC sp_recompile N'[Students].[Get]'