CREATE TABLE [product].[ProductColor] (
    [ProductColorId] INT IDENTITY (1, 1) NOT NULL,
    [ColorId]        INT NOT NULL,
    [ProductId]      INT NOT NULL,
    CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED ([ProductColorId] ASC),
    CONSTRAINT [FK_ProductColor_Color] FOREIGN KEY ([ColorId]) REFERENCES [common].[Color] ([ColorId]),
    CONSTRAINT [FK_ProductColor_Product] FOREIGN KEY ([ProductId]) REFERENCES [product].[Product] ([ProductId])
);



