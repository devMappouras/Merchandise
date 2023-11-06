CREATE TABLE [product].[ProductInventory] (
    [InventoryId]       INT      NOT NULL,
    [QuantityAvailable] INT      NOT NULL,
    [QuantityReserved]  INT      NOT NULL,
    [LastUpdated]       DATETIME NOT NULL,
    CONSTRAINT [PK_Product Inventory] PRIMARY KEY CLUSTERED ([InventoryId] ASC)
);

