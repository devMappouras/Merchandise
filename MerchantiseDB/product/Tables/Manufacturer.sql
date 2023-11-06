﻿CREATE TABLE [product].[Manufacturer] (
    [ManufacturerId]   INT           NOT NULL,
    [ManufacturerName] NVARCHAR (50) NOT NULL,
    [Location]         NVARCHAR (50) NULL,
    CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED ([ManufacturerId] ASC)
);

