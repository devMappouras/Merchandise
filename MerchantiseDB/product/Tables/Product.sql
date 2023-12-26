CREATE TABLE [product].[Product] (
    [ProductId]      INT             IDENTITY (1, 1) NOT NULL,
    [ProductName]    NVARCHAR (50)   NOT NULL,
    [Description]    NVARCHAR (350)  NULL,
    [Price]          DECIMAL (18, 2) NOT NULL,
    [DiscountId]     INT             NOT NULL,
    [CategoryId]     INT             NOT NULL,
    [ManufacturerId] INT             NULL,
    [InventoryId]    INT             NULL,
    [ColorId]        INT             NULL,
    [SizeId]         INT             NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_Discount] FOREIGN KEY ([DiscountId]) REFERENCES [product].[Discount] ([DiscountId]),
    CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY ([ManufacturerId]) REFERENCES [product].[Manufacturer] ([ManufacturerId]),
    CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [product].[ProductCategory] ([CategoryId]),
    CONSTRAINT [FK_Product_ProductInventory] FOREIGN KEY ([InventoryId]) REFERENCES [product].[ProductInventory] ([InventoryId]),
    CONSTRAINT [FK_Product_Color] FOREIGN KEY ([ColorId]) REFERENCES [common].[Color] ([ColorId]),
    CONSTRAINT [FK_Product_Size] FOREIGN KEY ([SizeId]) REFERENCES [common].[Size] ([SizeId])
);