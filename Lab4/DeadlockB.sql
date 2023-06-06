USE EarthNew
GO

BEGIN TRANSACTION
	UPDATE Religions set religion_name = 'Transaction2' WHERE religion_id = 2;
	GO
	WAITFOR DELAY '00:00:05';
	UPDATE Professions SET profession_name = 'Transaction2' WHERE profession_id = 3;
	GO
COMMIT TRANSACTION;
GO

SELECT * FROM Religions;
SELECT * FROM Professions;
GO

UPDATE Religions set religion_name = 'Atheism' WHERE religion_id = 2;
Go
UPDATE Professions SET profession_name = 'Engineer' WHERE profession_id = 3;
GO