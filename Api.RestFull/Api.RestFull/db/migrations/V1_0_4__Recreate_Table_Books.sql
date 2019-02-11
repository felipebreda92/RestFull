IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='books' AND xtype='U')
	CREATE TABLE books(
		Id bigint PRIMARY KEY IDENTITY NOT NULL,
		Author text,
		LauchDate datetime not null,
		Price decimal(38,2) not null,
		Title text
	)