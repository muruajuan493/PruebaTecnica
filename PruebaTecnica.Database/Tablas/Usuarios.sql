CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
    [NombreCompleto] VARCHAR(MAX) NOT NULL, 
    [NombreDeUsuario] VARCHAR(50) NOT NULL,
    [Contraseña] VARCHAR(50) NOT NULL,
    [ActivoActualmente] BIT NOT NULL, 
    [Estado] CHAR NOT NULL DEFAULT 'A', 
    [FechaDeAlta] SMALLDATETIME NOT NULL DEFAULT GetDate(), 
    [FechaDeBaja] SMALLDATETIME NULL
)
