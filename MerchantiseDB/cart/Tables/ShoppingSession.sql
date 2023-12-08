CREATE TABLE [cart].[ShoppingSession] (
    [SessionId]     INT             IDENTITY (1, 1) NOT NULL,
    [CustomerId]    INT             NOT NULL,
    [TotalPrice]    DECIMAL (18, 2) NOT NULL,
    [StartDateTime] DATETIME        NOT NULL,
    [EndDateTime]   DATETIME        NULL,
    CONSTRAINT [PK_ShoppingSession] PRIMARY KEY CLUSTERED ([SessionId] ASC),
    CONSTRAINT [FK_ShoppingSession_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [customer].[Customer] ([CustomerId])
);



