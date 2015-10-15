USE [db_LogMessage]
GO
/****** Object: Table [dbo].[Log] Script Date: 12/09/2015 10:03:08 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Log] (
    [IdLog]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion] NVARCHAR (200) NOT NULL,
    [Tipo_Mensaje]     CHAR (1)      NULL
);

