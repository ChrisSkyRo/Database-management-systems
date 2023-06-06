USE EarthNew
GO

INSERT INTO Professions(profession_name)
VALUES ('Clown');
GO

BEGIN TRANSACTION
	WAITFOR DELAY '00:00:05';
	UPDATE Professions SET profession_name = 'Animatronic' WHERE profession_name = 'Clown';
	GO
	WAITFOR DELAY '00:00:05';
COMMIT TRANSACTION;

SELECT * FROM Professions;
GO

DELETE FROM Professions WHERE profession_name = 'Animatronic';
GO