if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Students].[Get]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Students].[Get]
END
GO
CREATE PROCEDURE [Students].[Get]
	@StudentId	  INT = NULL
AS
BEGIN
	SELECT StudentId, Name, DateOfBirth, Email
	FROM Students
	WHERE @StudentId IS NULL OR (@StudentId IS NOT NULL AND StudentId = @StudentId)
END
GO
EXEC sp_recompile N'[Students].[Get]'

--EXEC [Students].[Get] 1
--EXEC [Students].[Get]