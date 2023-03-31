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
    "ChangeCheck" BLOB NULL,
    "Email" TEXT NOT NULL,
    "Password" TEXT NOT NULL,
    "Alias" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Categories" (
    "CategoryId" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Description" TEXT NULL,
    "MarketplaceId" INTEGER NULL,
    CONSTRAINT "FK_Categories_Marketplaces_MarketplaceId" FOREIGN KEY ("MarketplaceId") REFERENCES "Marketplaces" ("MarketplaceId")
);
CREATE TABLE IF NOT EXISTS "Offers" (
    "OfferId" INTEGER NOT NULL CONSTRAINT "PK_Offers" PRIMARY KEY AUTOINCREMENT,
    "ChangeCheck" BLOB NULL,
    "CategoryId" INTEGER NOT NULL,
    "SellerId" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    "Content" TEXT NULL,
    "PostalCode" TEXT NULL,
    "UserId" INTEGER NULL,
    CONSTRAINT "FK_Offers_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId")
);
CREATE TABLE IF NOT EXISTS "Orders" (
    "OrderId" INTEGER NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY AUTOINCREMENT,
    "ChangeCheck" BLOB NULL,
    "OfferId" INTEGER NOT NULL,
    "BuyerId" INTEGER NOT NULL,
    "TimeSlot" TEXT NULL,
    "UserId" INTEGER NULL,
    CONSTRAINT "FK_Orders_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId")
);
DELETE FROM sqlite_sequence;
CREATE INDEX "IX_Categories_MarketplaceId" ON "Categories" ("MarketplaceId");
CREATE INDEX "IX_Offers_UserId" ON "Offers" ("UserId");
CREATE INDEX "IX_Orders_UserId" ON "Orders" ("UserId");
COMMIT;
