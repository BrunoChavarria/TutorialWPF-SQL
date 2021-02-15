create database ConexionBDLibros
use ConexionBDLibros

create table Libros (
id int identity(1,1) primary key not null,
TituloLibro nvarchar(max)not null
)

create table Clientes(
id int identity (1,1) primary key not null,
Nombre nvarchar(15)not null,
Apellido nvarchar(15)not null
)

create table Pedidos(
id int identity (1,1) primary key not null,
idLibro int foreign key references Libros(id)not null,
idClientes int foreign key references Clientes(id)not null,
FechaPedido datetime default getdate()not null,
CantidadPedida int not null
)

go
create proc NuevoLibro
@TituloLibro nvarchar(max)
as
if(@TituloLibro = '')
	begin 
		print 'El Campo no puede quedar vacio'
	end
else
	begin
		insert into Libros values(@TituloLibro)
	end
go

create proc NuevoCliente
@Nombre nvarchar(15),
@Apellido nvarchar(15)
as
if(@Nombre = '' or @Apellido = '')
	begin
		print 'Los Campos no pueden quedar vacios'
	end
else 
	begin
		insert into Clientes values(@Nombre,@Apellido)
	end
go

create proc NuevoPedido
@NombreCliente nvarchar(15),
@ApellidoCliente nvarchar(15),
@TituloLibro nvarchar(max),
@Cantidad int
as
declare @fecha as datetime
declare @idCliente as int
declare @idLibro as int

if (@NombreCliente = '' or @ApellidoCliente = '' or @TituloLibro = '')
	begin
		print 'Los Campos no pueden quedar vacios'
	end
else 
	begin 
		set @idCliente = (select id from Clientes where Nombre = @NombreCliente and Apellido = @ApellidoCliente)
		set @idLibro = (select id from Libros where TituloLibro = @TituloLibro)
		set @fecha = getdate()

		insert into Pedidos values (@idLibro,@idCliente,@fecha,@Cantidad)
	end
go

create proc ListarLibros
as
select TituloLibro as 'Titulo del Libro' from Libros
go

create proc ListarClientes
as
select * from Clientes
go

create proc ListarPedidos
as
select Clientes.Nombre, Clientes.Apellido, Libros.TituloLibro as 'Titulo del libro', CantidadPedida as 'Cantidad de libros pedida' from Pedidos inner join Libros on Libros.id = Pedidos.idLibro
inner join Clientes on Clientes.id = Pedidos.idClientes
go