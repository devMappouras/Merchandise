CREATE TABLE [customer].[CustomerAddress] (
    [CustomerAddressId] INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId]        INT            NOT NULL,
    [StreetAddress]     NVARCHAR (200) NOT NULL,
    [City]              NVARCHAR (50)  NOT NULL,
    [State]             NVARCHAR (50)  NULL,
    [PostalCode]        NVARCHAR (50)  NOT NULL,
    [CountryId]         INT            NOT NULL,
    CONSTRAINT [PK_CustomerAddress] PRIMARY KEY CLUSTERED ([CustomerAddressId] ASC),
    CONSTRAINT [FK_CustomerAddress_Country] FOREIGN KEY ([CountryId]) REFERENCES [common].[Country] ([CountryId]),
    CONSTRAINT [FK_CustomerAddress_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [customer].[Customer] ([CustomerId])
);



