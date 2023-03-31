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
INSERT INTO Marketplaces VALUES(1,'Test-0b-0');
CREATE TABLE IF NOT EXISTS "Users" (
    "UserId" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "ChangeCheck" BLOB NULL,
    "Email" TEXT NOT NULL,
    "Password" TEXT NOT NULL,
    "Alias" TEXT NULL
);
INSERT INTO Users VALUES(1,NULL,'su','su',NULL);
CREATE TABLE IF NOT EXISTS "Categories" (
    "CategoryId" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Description" TEXT NULL,
    "MarketplaceId" INTEGER NULL,
    CONSTRAINT "FK_Categories_Marketplaces_MarketplaceId" FOREIGN KEY ("MarketplaceId") REFERENCES "Marketplaces" ("MarketplaceId")
);
INSERT INTO Categories VALUES(1,'Cat. 1','First test category',1);
INSERT INTO Categories VALUES(2,'Cat. 2','Second test category',1);
INSERT INTO Categories VALUES(3,'Cat. 3','Third test category',1);
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
INSERT INTO sqlite_sequence VALUES('Marketplaces',1);
INSERT INTO sqlite_sequence VALUES('Users',1);
INSERT INTO sqlite_sequence VALUES('Categories',3);
CREATE INDEX "IX_Categories_MarketplaceId" ON "Categories" ("MarketplaceId");
CREATE INDEX "IX_Offers_UserId" ON "Offers" ("UserId");
CREATE INDEX "IX_Orders_UserId" ON "Orders" ("UserId");
COMMIT;
