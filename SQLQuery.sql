﻿CREATE TABLE [dbo].[Brands] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[CarImages] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CarId]     INT            NOT NULL,
    [ImagePath] NVARCHAR (MAX) NOT NULL,
    [Date]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])
);

CREATE TABLE [dbo].[Cars] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [CarName]         NVARCHAR (50)  NOT NULL,
    [BrandId]         INT            NOT NULL,
    [ColorId]         INT            NOT NULL,
    [ModelYear]       INT            NOT NULL,
    [DailyPrice]      DECIMAL (18)   NOT NULL,
    [Description]     NVARCHAR (250) NOT NULL,
    [MinFindeksScore] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id])
);

CREATE TABLE [dbo].[Colors] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customers] (
	[UserId] [int] NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Address] [varchar](150) NULL,
	[FindeksScore] [int] NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Rentals] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [CarId]         INT      NOT NULL,
    [UserId]    INT      NOT NULL,
    [RentDate]      DATETIME NOT NULL,
    [ReturnDate]    DATETIME NOT NULL,
    [RentStartDate] DATETIME NULL,
    [RentEndDate]   DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Customers] ([UserId])
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [Email]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[FakeCard] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [NameOnTheCard]  NVARCHAR (150) NOT NULL,
    [CardNumber]     NVARCHAR (16)  NOT NULL,
    [CardCvv]        NCHAR (3)      NOT NULL,
    [expirationDate] NVARCHAR (50)  NOT NULL,
    [MoneyInTheCard] DECIMAL (18)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[CustomerCard] (
    [CardId] INT NOT NULL,
    [CustomerId]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CardId] ASC),
    FOREIGN KEY ([CardId]) REFERENCES [dbo].[FakeCard] ([Id]),
	FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([UserId])
);




