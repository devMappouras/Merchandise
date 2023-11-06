CREATE TABLE [product].[Discount] (
    [DiscountId]         INT           NOT NULL,
    [DscountName]        NVARCHAR (50) NULL,
    [DiscountPercentage] INT           NOT NULL,
    [StartDate]          DATETIME      NULL,
    [EndDate]            DATETIME      NULL,
    CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED ([DiscountId] ASC)
);

