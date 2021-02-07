CREATE TABLE Cars(
	CarID int PRIMARY KEY IDENTITY(1,1),
	CarName nvarchar(25),
	BrandID int,
	ColorID int,
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
)

CREATE TABLE Colors(
	ColorID int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

CREATE TABLE Brands(
	BrandID int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)

INSERT INTO Cars(CarName,BrandID,ColorID,ModelYear,DailyPrice,Descriptions)
VALUES
	('Renault Megane','3','5','2019','400','Manuel Benzin Hatchback'),
	('Audi A6','1','2','2012','100','Manuel Benzin Sedan'),
	('Renault Clio','3','3','2014','125','Manuel Dizel');

INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Kırmızı'),
	('Gri'),
	('Mavi');

INSERT INTO Brands(BrandName)
VALUES
	('Audi'),
	('BMW'),
	('Renault');
