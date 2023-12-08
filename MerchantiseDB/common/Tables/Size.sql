CREATE TABLE [common].[Size] (
    [SizeId]          INT           IDENTITY (1, 1) NOT NULL,
    [SizeName]        NVARCHAR (50) NOT NULL,
    [SizeDescription] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED ([SizeId] ASC)
);



