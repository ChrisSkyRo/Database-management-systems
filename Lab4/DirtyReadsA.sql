USE EarthNew
GO

BEGIN TRANSACTION
	SELECT * FROM Survivors;
	GO

	UPDATE Survivors
	SET survivor_name = 'Overlord'
	WHERE survivor_id = '1';
	GO

	WAITFOR DELAY '00:00:10';

ROLLBACK TRANSACTION