USE EarthNew
GO

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED -- SOLUTION: TRANSACTION ISOLATION LEVEL READ COMMITTED

BEGIN TRANSACTION	
	WAITFOR DELAY '00:00:05';

	SELECT * FROM Survivors;
	GO

COMMIT TRANSACTION