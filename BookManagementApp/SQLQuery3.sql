create table Book
(
	id int not null identity(1,1) primary key,
	name varchar(100) not null,
	isbn varchar(20) not null unique,
	author varchar(50) not null,
	categoryid int null,
	foreign key(categoryid) references Category(id)
)
go
Create VIEW BookCategory
as
SELECT b.id, b.name, b.isbn, b.author, b.categoryid, c.name as CategoryName from Book as b LEFT OUTER JOIN Category as c
ON b.categoryid = c.id
select * from BookCategory