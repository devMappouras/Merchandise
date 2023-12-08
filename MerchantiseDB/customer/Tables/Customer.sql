CREATE TABLE [customer].[Customer] (
    [CustomerId] INT           IDENTITY (1, 1) NOT NULL,
    [Email]      NVARCHAR (50) NOT NULL,
    [Password]   NVARCHAR (50) NULL,
    [Phone]      NVARCHAR (50) NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);



