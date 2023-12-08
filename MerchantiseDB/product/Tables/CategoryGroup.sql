CREATE TABLE [product].[CategoryGroup] (
    [GroupId]   INT           IDENTITY (1, 1) NOT NULL,
    [GroupName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CategoryGroup] PRIMARY KEY CLUSTERED ([GroupId] ASC)
);



