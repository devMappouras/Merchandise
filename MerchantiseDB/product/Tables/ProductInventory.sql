CREATE TABLE [product].[ProductInventory] (
    [InventoryId]       INT      IDENTITY (1, 1) NOT NULL,
    [QuantityAvailable] INT      NOT NULL,
    [QuantityReserved]  INT      NOT NULL,
    [LastUpdated]       DATETIME NOT NULL,
    CONSTRAINT [PK_Product Inventory] PRIMARY KEY CLUSTERED ([InventoryId] ASC)
);



