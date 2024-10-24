if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Students].[GetAll]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Students].[GetAll]
END
GO
CREATE PROCEDURE [Students].[GetAll]
AS
BEGIN
	SELECT StudentId, Name, DateOfBirth, Email
	FROM Students
END
GO
EXEC sp_recompile N'[Students].[GetAll]'