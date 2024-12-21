create database constructora
go

use constructora
go


create table Usuarios
(
UsuarioID int primary key identity(1,1),
Nombre varchar(50) not null,
CorreoElectronico varchar(100) not null,
Telefono varchar(13) not null,
Estado varchar(9) default('Activo')
)
go

create table empleados
(
EmpleadoID int primary key identity(1,1),
NumeroCarnet varchar(50) unique not null,
nombre varchar(50) not null,
fechanaNacimiento varchar(50) not null,
categoria varchar(50) not null,
Direccion varchar(100) default ('San José'),
Correo varchar(50) unique,
telefono varchar(50),
UsuarioID int foreign key references Usuarios not null,
Estado varchar(9) default('Activo')
)
go



create table Proyectos
(
ProyectoID int primary key identity(1,1),
nombre int foreign key references  empleados not null,
codigo int unique not null,
FechaAsignacion date not null,
FechaFinal date not null,
Estado varchar(9) default('Activo')
)
go




create table Asignaciones
(
AsignacionID int primary key identity(1,1),
EmpleadoID int foreign key references empleados not null,
ProyectoID int foreign key references proyectos not null,
FechaAsignacion date not null,

)
go

create procedure IngresarUsuario

@Nombre varchar(50),
@CorreoElectronico varchar(100),
@Telefono varchar(13),
@Estado varchar(9) 
as
	begin
		insert into Usuarios (Nombre, CorreoElectronico, Telefono,Estado) values (@nombre, @correoElectronico, @telefono,@Estado)
	end

go 


create procedure IngresarEmpleado
    @NumeroCarnet varchar(50), 
    @Nombre varchar(50),
    @FechaNacimiento varchar(50),
    @Categoria varchar(50),
    @Direccion varchar(100),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado varchar(9)
as
begin
    declare @Edad int
    set @Edad = DATEDIFF(year, CAST(@FechaNacimiento as date), GETDATE())

    if @Edad < 18
    begin
        print 'El empleado debe ser mayor de edad.'
        return
    end

    if not exists (select 1 from categorias where Categoria = @Categoria)
    begin
        print 'La categoría no es válida.'
        return
    end

    if exists (select 1 from empleados where Correo = @Correo)
    begin
        print 'El correo electrónico ya está registrado.'
        return
    end

    if exists (select 1 from empleados where NumeroCarnet = @NumeroCarnet)
    begin
        print 'El número de carnet ya está registrado.'
        return
    end

    insert into empleados(NumeroCarnet, Nombre, fechanaNacimiento, Categoria, Direccion, Correo, Telefono, Estado)
    values (@NumeroCarnet, @Nombre, @FechaNacimiento, @Categoria, @Direccion, @Correo, @Telefono, @Estado)
end
go

CREATE PROCEDURE ListarEmpleadosPorProyecto
    @ProyectoID INT
AS
BEGIN
    SELECT e.EmpleadoID, e.Nombre, e.Categoria, e.Correo, e.Telefono
    FROM Asignaciones a
    INNER JOIN Empleados e ON a.EmpleadoID = e.EmpleadoID
    WHERE a.ProyectoID = @ProyectoID
END
GO



create procedure IngresarProyecto
    @Nombre varchar(100),
    @EmpleadoID int,
    @Codigo int,
    @FechaAsignacion date,
    @FechaFinal date,
    @Estado varchar(9)
as
begin
    if exists (select 1 from Proyectos where Nombre = @Nombre)
    begin
        print 'El nombre del proyecto ya existe.'
        return
    end
    insert into Proyectos (Nombre,  Codigo, FechaAsignacion, FechaFinal, Estado)
    values (@Nombre, @Codigo, @FechaAsignacion, @FechaFinal, @Estado)
end
go



create procedure AsignarProyecto
    @EmpleadoID int,
    @ProyectoID int,
    @FechaAsignacion date
as
begin
    if exists (select 1 from Asignaciones where EmpleadoID = @EmpleadoID and ProyectoID = @ProyectoID)
    begin
        print 'El empleado ya está asignado a este proyecto.'
        return
    end

    insert into Asignaciones (EmpleadoID, ProyectoID, FechaAsignacion)
    values (@EmpleadoID, @ProyectoID, @FechaAsignacion)

    print 'Asignación realizada con éxito.'
end
go



CREATE PROCEDURE ListarProyectosPorEmpleado
    @EmpleadoID INT
AS
BEGIN
    SELECT p.ProyectoID, p.Nombre, p.Codigo, p.FechaAsignacion, p.FechaFinal
    FROM Asignaciones a
    INNER JOIN Proyectos p ON a.ProyectoID = p.ProyectoID
    WHERE a.EmpleadoID = @EmpleadoID
END
GO

CREATE PROCEDURE ListarEmpleadosPorCategoria
    @Categoria NVARCHAR(50)
AS
BEGIN
    SELECT EmpleadoID, Nombre, Categoria, Correo, Telefono
    FROM empleados
    WHERE Categoria = @Categoria
END