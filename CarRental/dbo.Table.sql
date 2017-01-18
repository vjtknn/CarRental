CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Brand] VARCHAR(50) NULL, 
    [Model] VARCHAR(50) NULL, 
    [Seats] INT NULL, 
    [Equipments] INT NULL, 
    CONSTRAINT [FK_Cars_ToTable] FOREIGN KEY ([Equipments]) REFERENCES [Equipments]([Id])
)
