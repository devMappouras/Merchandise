CREATE TABLE [customer].[CustomerPayment] (
    [PaymentId]  INT           NOT NULL,
    [CustomerId] INT           NOT NULL,
    [CardNumber] NVARCHAR (50) NULL,
    [ExpiryDate] DATE          NULL,
    CONSTRAINT [PK_CustomerPayment] PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    CONSTRAINT [FK_CustomerPayment_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [customer].[Customer] ([CustomerId])
);

