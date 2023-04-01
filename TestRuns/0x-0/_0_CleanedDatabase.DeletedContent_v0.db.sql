PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory VALUES('20230331164132_InitialSQLiteCreate','7.0.4');
CREATE TABLE IF NOT EXISTS "Marketplaces" (
    "MarketplaceId" INTEGER NOT NULL CONSTRAINT "PK_Marketplaces" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Users" (
    "UserId" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "Email" TEXT NOT NULL,
    "Password" TEXT NULL,
    "LastChangeTimestamp" BLOB NULL
);
CREATE TABLE IF NOT EXISTS "Categories" (
    "CategoryId" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "MarketplaceId" INTEGER NOT NULL,
    "Name" TEXT NOT NULL,
    "Description" TEXT NULL,
    CONSTRAINT "FK_Categories_Marketplaces_MarketplaceId" FOREIGN KEY ("MarketplaceId") REFERENCES "Marketplaces" ("MarketplaceId") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Offers" (
    "OfferId" INTEGER NOT NULL CONSTRAINT "PK_Offers" PRIMARY KEY AUTOINCREMENT,
    "UserId" INTEGER NOT NULL,
    "CategoryId" INTEGER NOT NULL,
    "LastChangeTimestamp" BLOB NULL,
    "SellerId" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    "Content" TEXT NULL,
    "Address_PostalCode" TEXT NULL,
    CONSTRAINT "FK_Offers_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Orders" (
    "OrderId" INTEGER NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY AUTOINCREMENT,
    "UserId" INTEGER NOT NULL,
    "OfferId" INTEGER NOT NULL,
    "OrderDetails_ReservationProposal_StartTime" TEXT NULL,
    "OrderDetails_ReservationProposal_EndTime" TEXT NULL,
    "Status" INTEGER NOT NULL,
    "LastChangeTimestamp" BLOB NULL,
    CONSTRAINT "FK_Orders_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('Marketplaces',2);
INSERT INTO sqlite_sequence VALUES('Users',3);
INSERT INTO sqlite_sequence VALUES('Categories',6);
CREATE INDEX "IX_Categories_MarketplaceId" ON "Categories" ("MarketplaceId");
CREATE INDEX "IX_Offers_UserId" ON "Offers" ("UserId");
CREATE INDEX "IX_Orders_UserId" ON "Orders" ("UserId");
COMMIT;
