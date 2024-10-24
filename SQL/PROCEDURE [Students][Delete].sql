if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Students].[Delete]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Students].[Delete]
END
GO
CREATE PROCEDURE [Students].[Delete]
	@StudentId	  INT
AS
BEGIN
	DELETE Students
	WHERE StudentId = @StudentId
END
GO
EXEC sp_recompile N'[Students].[Delete]'