USE EarthNew
GO

BEGIN TRANSACTION
	WAITFOR DELAY '00:00:05';
	INSERT INTO Professions(profession_name) VALUES ('Crawler');
	GO
	WAITFOR DELAY '00:00:05';
COMMIT TRANSACTION;
GO

SELECT * FROM Professions;
GO

DELETE FROM Professions WHERE profession_name = 'Crawler';
GO