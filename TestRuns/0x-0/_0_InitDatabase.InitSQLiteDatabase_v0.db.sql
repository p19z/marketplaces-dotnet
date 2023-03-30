PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory VALUES('20230330153406_InitialCreate','7.0.4');
CREATE TABLE IF NOT EXISTS "Marketplaces" (
    "MarketplaceId" INTEGER NOT NULL CONSTRAINT "PK_Marketplaces" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Users" (
    "UserId" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "Email" TEXT NOT NULL,
    "Password" TEXT NOT NULL,
    "Alias" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Categories" (
    "CategoryId" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NULL,
    "Content" TEXT NULL,
    "MarketplaceId" INTEGER NULL,
    CONSTRAINT "FK_Categories_Marketplaces_MarketplaceId" FOREIGN KEY ("MarketplaceId") REFERENCES "Marketplaces" ("MarketplaceId")
);
CREATE TABLE IF NOT EXISTS "Offers" (
    "OfferId" INTEGER NOT NULL CONSTRAINT "PK_Offers" PRIMARY KEY AUTOINCREMENT,
    "UserId" INTEGER NOT NULL,
    "CategoryId" INTEGER NOT NULL,
    "Title" TEXT NULL,
    "Content" TEXT NULL,
    CONSTRAINT "FK_Offers_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("CategoryId") ON DELETE CASCADE,
    CONSTRAINT "FK_Offers_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Orders" (
    "OrderId" INTEGER NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY AUTOINCREMENT,
    "UserId" INTEGER NOT NULL,
    "OfferId" INTEGER NOT NULL,
    "Title" TEXT NULL,
    "Content" TEXT NULL,
    CONSTRAINT "FK_Orders_Offers_OfferId" FOREIGN KEY ("OfferId") REFERENCES "Offers" ("OfferId") ON DELETE CASCADE,
    CONSTRAINT "FK_Orders_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);
DELETE FROM sqlite_sequence;
CREATE INDEX "IX_Categories_MarketplaceId" ON "Categories" ("MarketplaceId");
CREATE INDEX "IX_Offers_CategoryId" ON "Offers" ("CategoryId");
CREATE INDEX "IX_Offers_UserId" ON "Offers" ("UserId");
CREATE INDEX "IX_Orders_OfferId" ON "Orders" ("OfferId");
CREATE INDEX "IX_Orders_UserId" ON "Orders" ("UserId");
COMMIT;
