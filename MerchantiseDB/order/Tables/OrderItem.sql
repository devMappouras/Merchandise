CREATE TABLE [order].[OrderItem] (
    [OrderItemId] INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]     INT             NOT NULL,
    [ProductId]   INT             NOT NULL,
    [Quantity]    INT             NOT NULL,
    [UnitPrice]   DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([OrderItemId] ASC),
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderId]) REFERENCES [order].[Order] ([OrderId]),
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [product].[Product] ([ProductId])
);



