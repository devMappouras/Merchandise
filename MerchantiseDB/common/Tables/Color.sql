CREATE TABLE [common].[Color] (
    [ColorId]   INT           NOT NULL,
    [ColorName] NVARCHAR (50) NOT NULL,
    [ColorCode] NVARCHAR (10) NULL,
    CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

