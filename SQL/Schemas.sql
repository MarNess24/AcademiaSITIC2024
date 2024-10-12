IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'Students')
BEGIN
	EXEC('CREATE SCHEMA Students')
END

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'Courses')
BEGIN
	EXEC('CREATE SCHEMA Courses')
END

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'Enrollments')
BEGIN
	EXEC('CREATE SCHEMA Enrollments')
END