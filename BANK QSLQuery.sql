create database BANK;
use BANK;
create table Financial_transactions(
ID int identity(1,1) primary key,
Name Nvarchar(255) not null,
Date date not null,
Money int not null
);
insert into Financial_transactions(Name,Date,Money) values('На день рождения Дани', '2007.06.27', -250000);
insert into Financial_transactions(Name,Date,Money) values('На день рождения Егорика', '2007.12.11', -250);
insert into Financial_transactions(Name,Date,Money) values('На день рождения Кати', '2007.12.20', -1250000);
insert into Financial_transactions(Name,Date,Money) values('ЗП', '2025.02.23', +125250);