CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Case` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Img` longtext CHARACTER SET utf8mb4 NULL,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    `Del` longtext CHARACTER SET utf8mb4 NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_Case` PRIMARY KEY (`Id`)
);

CREATE TABLE `Course` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Year` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Course` PRIMARY KEY (`Id`)
);

CREATE TABLE `DataDictionary` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Key` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_DataDictionary` PRIMARY KEY (`Id`)
);

CREATE TABLE `Enterprise` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Img` longtext CHARACTER SET utf8mb4 NULL,
    `Remark` longtext CHARACTER SET utf8mb4 NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_Enterprise` PRIMARY KEY (`Id`)
);

CREATE TABLE `Honor` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Img` longtext CHARACTER SET utf8mb4 NULL,
    `Remark` longtext CHARACTER SET utf8mb4 NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_Honor` PRIMARY KEY (`Id`)
);

CREATE TABLE `Message` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `IsMess` tinyint(1) NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Phone` longtext CHARACTER SET utf8mb4 NULL,
    `Company` longtext CHARACTER SET utf8mb4 NULL,
    `Email` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_Message` PRIMARY KEY (`Id`)
);

CREATE TABLE `News` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Img` longtext CHARACTER SET utf8mb4 NULL,
    `Type` int NOT NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_News` PRIMARY KEY (`Id`)
);

CREATE TABLE `Recruitment` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    `Type` int NOT NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_Recruitment` PRIMARY KEY (`Id`)
);

CREATE TABLE `Study` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_Study` PRIMARY KEY (`Id`)
);

CREATE TABLE `Team` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Img` longtext CHARACTER SET utf8mb4 NULL,
    `Remark` longtext CHARACTER SET utf8mb4 NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_Team` PRIMARY KEY (`Id`)
);

CREATE TABLE `User` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `LoginName` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    `IsAction` tinyint(1) NOT NULL,
    `CreateTime` datetime(6) NULL,
    CONSTRAINT `PK_User` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200702154100_Initial', '3.1.5');

ALTER TABLE `User` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Team` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Study` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Recruitment` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `News` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Message` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Honor` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Enterprise` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `DataDictionary` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Course` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Case` ADD `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200705140330_Add_IsDeleted', '3.1.5');

