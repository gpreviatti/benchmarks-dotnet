USE benchmarks
GO

-- Inserts for Address
INSERT INTO Address (State, Neighbordhood, Country, City, ZipCode)
VALUES
('State1', 'Neighbordhood1', 'Country1', 'City1', 'Zip1'),
('State2', 'Neighbordhood2', 'Country2', 'City2', 'Zip2'),
('State3', 'Neighbordhood3', 'Country3', 'City3', 'Zip3')
GO

-- Inserts for Person
INSERT INTO Person (Name, Email, BirthDate, AddressId)
VALUES
('Name1', 'email1@example.com', '2000-01-01', (SELECT TOP 1 Id FROM [Address] ORDER BY NEWID())),
('Name2', 'email2@example.com', '2000-01-02', (SELECT TOP 1 Id FROM [Address] ORDER BY NEWID())),
('Name3', 'email3@example.com', '2000-01-03', (SELECT TOP 1 Id FROM [Address] ORDER BY NEWID()))
GO

-- Inserts for Account
INSERT INTO Account (Description, AccountType, UserId)
VALUES
('Description1', 'Type1', (SELECT TOP 1 Id FROM Person ORDER BY NEWID())),
('Description2', 'Type2', (SELECT TOP 1 Id FROM Person ORDER BY NEWID())),
('Description3', 'Type3', (SELECT TOP 1 Id FROM Person ORDER BY NEWID()))
GO
