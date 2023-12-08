CREATE TABLE [product].[ProductSize] (
    [ProductSizeId] INT IDENTITY (1, 1) NOT NULL,
    [SizeId]        INT NOT NULL,
    [ProductId]     INT NOT NULL,
    CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED ([ProductSizeId] ASC),
    CONSTRAINT [FK_ProductSize_Product] FOREIGN KEY ([ProductId]) REFERENCES [product].[Product] ([ProductId]),
    CONSTRAINT [FK_ProductSize_Size] FOREIGN KEY ([SizeId]) REFERENCES [common].[Size] ([SizeId])
);



