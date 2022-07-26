CREATE TABLE [dbo].[TiposDeIdentificacion]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
    [Abreviatura] CHAR(10) NOT NULL, 
    [Descripcion] VARCHAR(150) NOT NULL,
    [Estado] CHAR NOT NULL DEFAULT 'A', 
    [FechaDeAlta] SMALLDATETIME NOT NULL DEFAULT GetDate(), 
    [FechaDeBaja] SMALLDATETIME NULL
)
