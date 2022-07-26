CREATE TABLE [dbo].[Clientes]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
    [Nombre] VARCHAR(MAX) NOT NULL, 
    [Apellido] VARCHAR(50) NOT NULL, 
    [FechaDeNacimiento] SMALLDATETIME NOT NULL, 
    [IdGenero] INT NOT NULL, 
    [IdTipoDeIdentificacion] INT NOT NULL, 
    [NumeroDeIdentificacion] NCHAR(10) NOT NULL, 
    [Maneja] BIT NOT NULL, 
    [UsaLentes] BIT NOT NULL, 
    [TieneDiabetes] BIT NOT NULL, 
    [TieneOtrasEnfermedades] BIT NOT NULL, 
    [OtrasEnfermedades] NVARCHAR(MAX) NULL,
    [ActivoActualmente] BIT NOT NULL, 
    [Estado] CHAR NOT NULL DEFAULT 'A', 
    [FechaDeAlta] SMALLDATETIME NOT NULL DEFAULT GetDate(), 
    [FechaDeBaja] SMALLDATETIME NULL, 
)
