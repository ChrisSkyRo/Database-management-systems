USE EarthNew
GO

BEGIN TRANSACTION
	UPDATE Professions SET profession_name = 'Transaction1' WHERE profession_id = 3;
	GO
	WAITFOR DELAY '00:00:05';
	UPDATE Religions set religion_name = 'Transaction1' WHERE religion_id = 2;
	GO
COMMIT TRANSACTION;
GO

SELECT * FROM Professions;
SELECT * FROM Religions;
GO

UPDATE Religions set religion_name = 'Atheism' WHERE religion_id = 2;
Go
UPDATE Professions SET profession_name = 'Engineer' WHERE profession_id = 3;
GO
