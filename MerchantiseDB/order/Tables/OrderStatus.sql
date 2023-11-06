CREATE TABLE [order].[OrderStatus] (
    [OrderStatusId] INT           NOT NULL,
    [StatusName]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED ([OrderStatusId] ASC)
);

