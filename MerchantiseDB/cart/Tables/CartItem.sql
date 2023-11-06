CREATE TABLE [cart].[CartItem] (
    [CartItemId] INT             NOT NULL,
    [SessionId]  INT             NOT NULL,
    [ProductId]  INT             NOT NULL,
    [Quantity]   INT             NOT NULL,
    [UnitPrice]  DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED ([CartItemId] ASC),
    CONSTRAINT [FK_CartItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [product].[Product] ([ProductId]),
    CONSTRAINT [FK_CartItem_ShoppingSession] FOREIGN KEY ([SessionId]) REFERENCES [cart].[ShoppingSession] ([SessionId])
);

