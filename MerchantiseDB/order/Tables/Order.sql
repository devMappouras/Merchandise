CREATE TABLE [order].[Order] (
    [OrderId]           INT             NOT NULL,
    [CustomerId]        INT             NOT NULL,
    [OrderDate]         DATETIME        NOT NULL,
    [TotalPrice]        DECIMAL (18, 2) NOT NULL,
    [OrderStatusId]     INT             NOT NULL,
    [ShippingAddressId] INT             NOT NULL,
    [PaymentDetailId]   INT             NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [customer].[Customer] ([CustomerId]),
    CONSTRAINT [FK_Order_CustomerAddress] FOREIGN KEY ([ShippingAddressId]) REFERENCES [customer].[CustomerAddress] ([CustomerAddressId]),
    CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY ([OrderStatusId]) REFERENCES [order].[OrderStatus] ([OrderStatusId]),
    CONSTRAINT [FK_Order_PaymentDetail] FOREIGN KEY ([PaymentDetailId]) REFERENCES [order].[PaymentDetail] ([PaymentDetailId])
);

