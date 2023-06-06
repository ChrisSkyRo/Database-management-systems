USE EarthNew
GO

CREATE OR ALTER PROCEDURE AddSurvivorAndGood
    @survivor_name varchar(50),
    @birthdate date,
    @profession_id INT,
    @workplace_id INT,
    @building_id INT,
    @religion_id INT,
    @good_name varchar(50),
    @quantity INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validate survivor_name is not null
        IF @survivor_name IS NULL
        BEGIN
            RAISERROR('Survivor name cannot be null.', 16, 1);
            RETURN;
        END

		-- Validate survivor_name doesn't already exist
        IF EXISTS (SELECT 1 FROM Survivors WHERE survivor_name = @survivor_name)
        BEGIN
            RAISERROR('Survivor name already exists.', 16, 1);
            RETURN;
        END

        -- Validate profession_id existence
        IF NOT EXISTS (SELECT 1 FROM Professions WHERE profession_id = @profession_id)
        BEGIN
            RAISERROR('Invalid profession_id. Profession not found.', 16, 1);
            RETURN;
        END

        -- Validate workplace_id existence
        IF @workplace_id IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Workplaces WHERE workplace_id = @workplace_id)
        BEGIN
            RAISERROR('Invalid workplace_id. Workplace not found.', 16, 1);
            RETURN;
        END

        -- Validate building_id existence
        IF @building_id IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Buildings WHERE building_id = @building_id)
        BEGIN
            RAISERROR('Invalid building_id. Building not found.', 16, 1);
            RETURN;
        END

        -- Validate religion_id existence
        IF @religion_id IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Religions WHERE religion_id = @religion_id)
        BEGIN
            RAISERROR('Invalid religion_id. Religion not found.', 16, 1);
            RETURN;
        END

		-- Validate good_name doesn't already exist
        IF EXISTS (SELECT 1 FROM Goods WHERE good_name = @good_name)
        BEGIN
            RAISERROR('Good name already exists.', 16, 1);
            RETURN;
        END

        -- Validate quantity is a positive integer
        IF @quantity <= 0
        BEGIN
            RAISERROR('Invalid quantity. Quantity should be a positive integer.', 16, 1);
            RETURN;
        END

        DECLARE @survivor_id INT, @good_id INT;

        -- Insert into Survivors table
        INSERT INTO Survivors (survivor_name, birthdate, profession_id, workplace_id, building_id, religion_id)
        VALUES (@survivor_name, @birthdate, @profession_id, @workplace_id, @building_id, @religion_id);

        -- Get the generated survivor_id
        SET @survivor_id = SCOPE_IDENTITY();

        -- Insert into Goods table
        INSERT INTO Goods (good_name, quantity)
        VALUES (@good_name, @quantity);

        -- Get the generated good_id
        SET @good_id = SCOPE_IDENTITY();

        -- Insert into Production table
        INSERT INTO Production (survivor_id, good_id) VALUES (@survivor_id, @good_id);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        -- Raise the error message
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END
GO

EXEC AddSurvivorAndGood
    @survivor_name = 'John Doe',
    @birthdate = '1990-01-01',
    @profession_id = 10,
    @workplace_id = 2,
    @building_id = 3,
    @religion_id = 4,
    @good_name = 'Item A',
    @quantity = 5;

GO
