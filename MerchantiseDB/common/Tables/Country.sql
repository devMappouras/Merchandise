CREATE TABLE [common].[Country] (
    [CountryId]   INT            IDENTITY (1, 1) NOT NULL,
    [CountryName] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);



