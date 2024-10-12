if EXISTS ( SELECT 1 FROM sys.objects
		    WHERE object_id = OBJECT_ID(N'[Students].[Insert]') AND
		    type in (N'P', N'PC'))

BEGIN 
	DROP PROCEDURE [Students].[Insert]
END
GO
CREATE PROCEDURE [Students].[Insert]
	@Name		  VARCHAR(150),
	@DateOfBirth  DATE,
	@Email		  VARCHAR(100),
	@StudentId	  INT OUT
WITH ENCRYPTION 
AS
BEGIN
	INSERT INTO Students(Name, DateOfBirth, Email) VALUES (@Name, @DateOfBirth, @Email)
	SET @StudentId = SCOPE_IDENTITY()
END
GO
EXEC sp_recompile N'[Students].[Insert]'