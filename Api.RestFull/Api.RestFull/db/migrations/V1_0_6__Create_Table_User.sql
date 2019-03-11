CREATE TABLE users(
	Id int not null identity(1,1) primary key,
	Login varchar(50) unique not null,
	AccessKey varchar(50) not null,
)