CREATE TABLE [order].[PaymentDetail] (
    [PaymentDetailId]   INT            IDENTITY (1, 1) NOT NULL,
    [PaymentId]         INT            NULL,
    [TransactionDate]   DATETIME       NOT NULL,
    [PaymentStatusId]   INT            NOT NULL,
    [AdditionalDetails] NVARCHAR (500) NULL,
    CONSTRAINT [PK_PaymentDetail] PRIMARY KEY CLUSTERED ([PaymentDetailId] ASC),
    CONSTRAINT [FK_PaymentDetail_CustomerPayment] FOREIGN KEY ([PaymentId]) REFERENCES [customer].[CustomerPayment] ([PaymentId])
);



