CREATE DATABASE FrikimundoDB;
GO

USE FrikimundoDB
GO

CREATE TABLE [dbo].[PeliculasTable] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]   NVARCHAR (50) NULL,
    [Director] NVARCHAR (50) NULL,
    [Genero]   NVARCHAR (50) NULL,
    [Fecha]    DATE          DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[SeriesTable] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]     NVARCHAR (50) NULL,
    [Genero]     NCHAR (10)    NULL,
    [Temporasas] INT           NULL,
    [Capitulos]  INT           NULL,
    [Fecha]      DATE          DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[LibrosTable] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]         NVARCHAR (50) NULL,
    [Autor]          NVARCHAR (50) NULL,
    [Genero]         NVARCHAR (50) NULL,
    [Saga literaria] NVARCHAR (50) NULL,
    [Fecha]          DATE          DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[VideoJuegosTable] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]     NVARCHAR (50) NULL,
    [Plataforma] NVARCHAR (50) NULL,
    [Genero]     NVARCHAR (50) NULL,
    [Fecha]      DATE          DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AnimesTable] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]     NVARCHAR (50) NULL,
    [Genero]     NVARCHAR (50) NULL,
    [Capitulos]  INT           NULL,
    [Temporadas] INT           NULL,
    [Fecha]      DATE          DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ComicsMangasTable] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]    NVARCHAR (50) NULL,
    [Autor]     NVARCHAR (50) NULL,
    [Genero]    NVARCHAR (50) NULL,
    [Capitulos] INT           NULL,
    [Tomos]     INT           NULL,
    [Fecha]     DATE          DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT PeliculasTable ON;
INSERT INTO PeliculasTable (Id, Titulo, Director, Genero, Fecha)
VALUES
(1, 'Masacre en Texas', 'Tobe Hooper', 'Terror/Crimen', GETDATE()),
(2, 'Matrix', 'Hachowski', 'Sci-fi', GETDATE()),
(3, 'Apocalypse now', 'Francis Ford Coppola', 'Bélico/Acción', GETDATE());
SET IDENTITY_INSERT PeliculasTable OFF;


SET IDENTITY_INSERT SeriesTable ON;
INSERT INTO SeriesTable (Id, Titulo, Genero, Temporasas, Capitulos, Fecha)
VALUES
(1, 'Mad Men', 'Drama', 7, 92 , GETDATE()),
(2, 'Succession', 'Drama', 4, 39 , GETDATE()),
(3, 'The Boys', 'Drama', 4, 32 , GETDATE());
SET IDENTITY_INSERT SeriesTable OFF;


SET IDENTITY_INSERT LibrosTable ON;
INSERT INTO LibrosTable (Id, Titulo, Autor, Genero, [Saga literaria], Fecha)
VALUES
(1, 'Fahrenheit 451', 'Ray Bradbury', 'Sci-fi', 'no tiene' , GETDATE()),
(2, 'El último deseo', 'Andrzej Sapkowski', ' Género fantástico', 'Saga del Brujo' , GETDATE()),
(3, 'El retrato de Dorian Gray', 'Oscar Wilde', ' Ficción gótica', 'no tiene' , GETDATE()),
(4, 'El psicoanalista', 'John Katzenbach', 'Thriller', 'El psicoanalista' , GETDATE());
SET IDENTITY_INSERT LibrosTable OFF;


SET IDENTITY_INSERT VideoJuegosTable ON;
INSERT INTO VideoJuegosTable (Id, Titulo, Plataforma, Genero, Fecha)
VALUES
(1, 'The leyend of Zelda', 'Nintendo', 'Aventura' , GETDATE()),
(2, 'Monster Hunter 3rd', 'PSP', 'ARPG' , GETDATE()),
(3, 'The Last of Us', 'PS3', 'Accion/Aventura' , GETDATE());
SET IDENTITY_INSERT VideoJuegosTable OFF;


SET IDENTITY_INSERT AnimesTable ON;
INSERT INTO AnimesTable (Id, Titulo, Genero, Capitulos, Temporadas, Fecha)
VALUES
(1, 'Evangelion', 'Sci-fi', 24, 1 , GETDATE()),
(2, 'Gintama', 'Accion', 367, 10 , GETDATE()),
(3, 'Naruto', 'Accion', 220, 5 , GETDATE());
SET IDENTITY_INSERT AnimesTable OFF;


SET IDENTITY_INSERT ComicsMangasTable ON;
INSERT INTO ComicsMangasTable (Id, Titulo, Autor, Genero, Capitulos, Tomos, Fecha)
VALUES
(1, 'The Sandman', 'Neil Gaiman',  ' Fantasía oscura', 75,10, GETDATE()),
(2, 'Uzumaki', 'Junji Ito',  'Terror', 19,3, GETDATE()),
(3, 'Watchmen', 'Alan Moore',  'Sci-fi', 12,1, GETDATE()),
(4, 'Berserk', 'Kentaro Miura',  'Fantasía oscura', 370,23, GETDATE());
SET IDENTITY_INSERT ComicsMangasTable OFF;