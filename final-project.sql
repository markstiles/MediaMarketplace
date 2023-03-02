if not exists(select * from sys.databases where name='MediaMarketplace')
	create database MediaMarketplace
go

use MediaMarketplace
go


--Down
drop view if exists v_copyright_sales
drop view if exists v_copyrights

drop trigger if exists t_copyright_sales_update_active

if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_license_sales_copyright_id')
		alter table license_sales drop constraint fk_license_sales_copyright_id 
if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_license_sales_buyer_id')
		alter table license_sales drop constraint fk_license_sales_buyer_id 
if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_licenses_copyright_id')
		alter table licenses drop constraint fk_licenses_copyright_id 
if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_copyright_sales_buyer_id')
		alter table copyright_sales drop constraint fk_copyright_sales_buyer_id 
if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_copyright_sales_seller_id')
		alter table copyright_sales drop constraint fk_copyright_sales_seller_id 
if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_copyright_sales_copyright_id')
		alter table copyright_sales drop constraint fk_copyright_sales_copyright_id 
if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_copyrights_user_id')
		alter table copyrights drop constraint fk_copyrights_user_id
if exists(select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where CONSTRAINT_NAME='fk_payment_informations_user_id')
		alter table payment_informations drop constraint fk_payment_informations_user_id

drop table if exists license_sales
drop table if exists licenses
drop table if exists copyright_sales
drop table if exists copyrights
drop table if exists payment_informations 
drop table if exists users 

GO

-- Up Metadata
create table users (
	user_id int identity not null,
	user_email varchar(100) not null,
	user_password varchar(100) not null,
	user_business_name varchar(100),
	user_first_name varchar(100) not null,
	user_last_name varchar(100) not null,
	user_phone_number varchar(11),
	constraint pk_users_id primary key (user_id),
	constraint u_users_email unique (user_email)
)

create table payment_informations (
	payment_information_id int identity not null,
	payment_information_user_id int not null,
	payment_information_bank_account char(12) not null,
	payment_information_routing_number char(9) not null,
	constraint pk_payment_informations_id primary key (payment_information_id, payment_information_user_id),
	constraint u_payment_informations_bank_account unique (payment_information_bank_account)
)
alter table payment_informations 
	add constraint fk_payment_informations_user_id foreign key (payment_information_user_id)
		references users(user_id)

create table copyrights (
	copyright_id int identity not null,
	copyright_user_id int not null,
	copyright_name varchar(50) not null,
	copyright_media_type varchar(50) not null,
	copyright_file varchar(max) not null,
	copyright_active bit not null default 1,
	constraint pk_copyrights_id primary key (copyright_id, copyright_user_id)
)
alter table copyrights 
	add constraint fk_copyrights_user_id foreign key (copyright_user_id)
		references users(user_id)

create table copyright_sales (
	copyright_sale_id int identity not null,
	copyright_sale_copyright_id int not null,
	copyright_sale_seller_id int not null,
	copyright_sale_buyer_id int,
	copyright_sale_create_date datetime not null,
	copyright_sale_close_date datetime,
	copyright_sale_sale_price money not null,
	copyright_sale_active bit not null default 1,
	constraint pk_copyright_sales_id primary key (copyright_sale_id, copyright_sale_copyright_id, copyright_sale_seller_id)
)
alter table copyright_sales 
	add constraint fk_copyright_sales_copyright_id foreign key (copyright_sale_copyright_id)
		references copyrights(copyright_id)
alter table copyright_sales 
	add constraint fk_copyright_sales_seller_id foreign key (copyright_sale_seller_id)
		references users(user_id)
alter table copyright_sales 
	add constraint fk_copyright_sales_buyer_id foreign key (copyright_sale_buyer_id)
		references users(user_id)

create table licenses (
	license_id int identity not null,
	license_type varchar(50) not null,
	license_copyright_id int not null,
	license_start_date date not null,
	license_end_date date not null,
	license_cost money not null,
	constraint pk_licenses_id primary key (license_id, license_copyright_id)
)
alter table licenses 
	add constraint fk_licenses_copyright_id foreign key (license_copyright_id)
		references copyrights(copyright_id)

create table license_sales (
	license_sale_id int identity not null,
	license_sale_type varchar(50) not null,
	license_sale_buyer_id int not null,
	license_sale_copyright_id int not null,
	license_sale_start_date date not null,
	license_sale_end_date date not null,
	license_sale_sales_price money not null,
	license_sale_create_date datetime not null,
	constraint pk_license_sales_id primary key (license_sale_id, license_sale_buyer_id, license_sale_copyright_id)
)
alter table license_sales 
	add constraint fk_license_sales_buyer_id foreign key (license_sale_buyer_id)
		references users(user_id)
alter table license_sales 
	add constraint fk_license_sales_copyright_id foreign key (license_sale_copyright_id)
		references copyrights(copyright_id)
		
go

create trigger t_copyright_sales_update_active on copyright_sales after update as 
	update copyright_sales
	set copyright_sale_active = 0
	where copyright_sale_id in (select distinct copyright_sale_id from inserted) and copyright_sale_close_date is not null

go

create view v_copyrights as 
select 
	copyright_id,
	copyright_name,
	copyright_media_type,
	copyright_file,
	copyright_user_id	
from copyrights c where copyright_active = 1

go 

create view v_copyright_sales as 
select 
	copyright_sale_id,
	copyright_sale_copyright_id,
	copyright_sale_seller_id,
	copyright_sale_buyer_id,
	copyright_sale_create_date,
	copyright_sale_close_date,
	copyright_sale_sale_price
from copyright_sales c where copyright_sale_active = 1

go

--Verify
select * from license_sales
select * from licenses
select * from copyright_sales
select * from copyrights
select * from payment_informations
select * from users 