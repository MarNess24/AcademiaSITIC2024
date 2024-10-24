if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Students].[Update]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Students].[Update]
END
GO
CREATE PROCEDURE [Students].[Update]
	@StudentId	  INT,
	@Name		  VARCHAR(150),
	@DateOfBirth  DATE,
	@Email		  VARCHAR(100)
AS
BEGIN
	UPDATE Students 
	SET Name = @Name,
		DateOfBirth = @DateOfBirth,
		Email = @Email
	WHERE StudentId = @StudentId
END
GO
EXEC sp_recompile N'[Students].[Update]'