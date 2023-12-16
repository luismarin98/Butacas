use "Butacas";

if not exists (select * from sys.databases where name='BaseEntity')
begin
	create table "BaseEntity" (
		"id_base" int not null primary key,
		"Status" bit not null
	);
end

if not exists (select * from sys.databases where name='CustomerEntity')
begin
	create table "CustomerEntity" (
		"id_customer" int not null primary key,
		"DocumentNumber" int not null,
		"name" nvarchar (30) not null,
		"latname" nvarchar (30) not null,
		"Age" int not null,
		"PhoneNumber" int not null,
		"Email" nvarchar(30) not null,
	);
end

if not exists (select * from sys.databases where name='MovieEntity')
begin
	create table "MovieEntity" (
		"id_movie" int not null primary key,
		"Name" nvarchar(30) not null,
		"MovieGenreEnum" nvarchar(30) not null,
		"AllowedAge" int not null,
		"LengthMinutes" int not null
	);
end

if not exists (select * from sys.databases where name='RoomEntity')
begin
	create table "RoomEntity" (
		"id_room" int not null primary key,
		"Name" nvarchar(30) not null,
		"Number" int not null,
	);
end

if not exists (select * from sys.databases where name='SeatEntity')
begin
	create table "SeatEntity" (
		"id_seat" int not null primary key,
		"id_room" int not null,
		"Number" nvarchar(30) not null,
		"RowNumber" int not null,
		foreign key ("id_room") references "RoomEntity"("id_room")
	);
end

if not exists (select * from sys.databases where name='BillboardEntity')
begin
	create table "BillboardEntity " (
		"id_billboard" int not null primary key,
		"id_movie" int not null,
		"id_room" int not null,
		"Date" datetime not null,
		"StartTime" datetime not null,
		"EndTime" datetime not null,
		foreign key ("id_movie") references "MovieEntity"("id_movie"),
		foreign key ("id_room") references "RoomEntity"("id_room")
	);
end

if not exists (select * from sys.databases where name='BookingEntity')
begin
	create table "BookingEntity" (
		"id_bookin" int not null primary key,
		"id_customer" int not null,
		"id_billboard" int not null,
		"id_seat" int not null,
		"Date" datetime not null,
		foreign key ("id_customer") references "CustomerEntity"("id_customer"),
		foreign key ("id_seat") references "SeatEntity"("id_seat"),
		foreign key ("id_billboard") references "BillboardEntity "("id_billboard")
	);
end