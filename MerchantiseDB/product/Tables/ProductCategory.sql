CREATE TABLE [product].[ProductCategory] (
    [CategoryId]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    [GroupId]      INT           NOT NULL,
    CONSTRAINT [PK_Product Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_ProductCategory_CategoryGroup] FOREIGN KEY ([GroupId]) REFERENCES [product].[CategoryGroup] ([GroupId])
);



