/*
--BASE DE DATOS: MISUPER
--EQUIPO DESARROLLADOR : TECHNOCODE
*/

USE tempdb
GO


 alter database SUPERMERCADO set single_user with rollback immediate

IF EXISTS(SELECT * FROM sys.databases WHERE name='SUPERMERCADO')
BEGIN
	DROP DATABASE SUPERMERCADO;
END
GO

CREATE DATABASE SUPERMERCADO
ON PRIMARY
(
	NAME='SUPERMERCADO_DATA',
	FILENAME='C:\supermercadoMiSuper\SUPERMERCADO_DATA.mdf',
	SIZE=10MB,
	MAXSIZE=800MB,
	FILEGROWTH=5MB
)
LOG ON
(
	NAME='SUPERMERCADO_LOG',
	FILENAME='C:\supermercadoMiSuper\SUPERMERCADO_LOG.ldf',
	SIZE=10MB,
	MAXSIZE=600MB,
	FILEGROWTH=5MB
)
GO

USE SUPERMERCADO
GO


CREATE SCHEMA PRODUCTO 
GO

CREATE SCHEMA PERSONA
GO

CREATE SCHEMA REGISTRO
GO

CREATE TABLE PERSONA.Cliente
(
 idCliente INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
 nombreCliente NVARCHAR(50) NOT NULL,
 apellidoCliente NVARCHAR(80) NOT NULL,
 identidad NVARCHAR(15) NOT NULL,
 estadoCliente VARCHAR (20)  DEFAULT ('ACTIVO/A') NULL,
 vecesCompra INT NULL,
 sexo CHAR(1) NOT NULL,
 telefono CHAR(9) NULL,
 direccion TEXT NULL,
 correoCliente NVARCHAR(80) NULL
)

CREATE TABLE PERSONA.Empleado
(
 idEmpleado INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
 nombreEmpleado NVARCHAR(50) NOT NULL,
 apellidoEmpleado NVARCHAR(80) NOT NULL,
 fechaIngreso NVARCHAR(8) NOT NULL,
 puesto NVARCHAR(60) NOT NULL,
 estadoEmpleado VARCHAR (20)  DEFAULT ('ACTIVO/A') NULL,
 sexo CHAR(1) NOT NULL,
 telefono CHAR(9) NULL,
 direccion TEXT NOT NULL,
 correoEmpleado NVARCHAR(80) NOT NULL
)

CREATE TABLE PERSONA.Usuario
( 
 idUsuario INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
 nombreUsuario NVARCHAR(25) NOT NULL,
 passwordUsuario NVARCHAR(12) NOT NULL,
 estadoUsuario VARCHAR (20)  DEFAULT ('ACTIVO/A') NULL,
 nivelUsuario NVARCHAR(15) NOT NULL
)

CREATE TABLE PRODUCTO.Proveedor
(
 idProveedor INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
 nombreProveedor NVARCHAR(50) NOT NULL,
 telefonoProveedor CHAR(9) NOT NULL,
 celularProveedor CHAR(9) NULL,
 direccionProveedor TEXT NOT NULL,
 descripcionProveedor TEXT NULL,
 estadoProveedor VARCHAR (20)  DEFAULT ('ACTIVO/A') NULL,
 correoProveedor NVARCHAR(80) NOT NULL
)

CREATE TABLE PRODUCTO.CategoriaProducto
(
 idCategoriaProducto INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
 estadoCategoriaProducto VARCHAR (20)  DEFAULT ('ACTIVO/A') NULL,
 nombreCategoria NVARCHAR(30) NOT NULL
)


CREATE TABLE PRODUCTO.Producto
(
 idProducto INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
 idProveedor INT NOT NULL,
 idCategoriaProducto INT NOT NULL,
 nombreProducto NVARCHAR(50) NOT NULL,
 estadoProducto VARCHAR (20)  DEFAULT ('ACTIVO/A') NULL,
 stock INT NOT NULL,
 precio DECIMAL(10,2) NOT NULL,
 marca NVARCHAR(40) NOT NULL,
 fechaCaducidad DATE NOT NULL
)

CREATE TABLE REGISTRO.Movimiento
(
	idMovimiento INT IDENTITY (1,1),
	fechaMovimineto DATETIME DEFAULT GETDATE() NOT NULL,
	operacion VARCHAR(100) NOT NULL,
	tabla VARCHAR(20) NOT NULL, 
	descripcion TEXT NULL,
	encargado INT NOT NULL 
)
GO

CREATE TABLE REGISTRO.Factura
(
 idFactura INT IDENTITY (1,1) PRIMARY KEY CLUSTERED,
 idCliente INT NOT NULL,
 idEmpleado INT NOT NULL,
 fecha DATETIME DEFAULT GETDATE(),
 total DECIMAL(10,2) default 0 
 --total DECIMAL(10,2) NULL
)

CREATE TABLE REGISTRO.DetalleFactura
(
 IdDetalle INT IDENTITY (1,1) PRIMARY KEY CLUSTERED,
 IdFactura INT NOT NULL,
 IdProducto INT NOT NULL,
 cantidad INT NOT NULL,
 Total DECIMAL(10,2) NOT NULL
)

ALTER TABLE PRODUCTO.Producto
ADD CONSTRAINT FK_PRODUCTO_PRODUCTO$TIENE_UN$PRODUCTO_PROVEEDOR
FOREIGN KEY (idProveedor) REFERENCES PRODUCTO.Proveedor (idProveedor)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO


ALTER TABLE PRODUCTO.Producto
ADD CONSTRAINT FK_PRODUCTO_PRODUCTO$TIENE_UNA$PRODUCTO_CATEGORIAPRODUCTO
FOREIGN KEY (idCategoriaProducto) REFERENCES PRODUCTO.CategoriaProducto (idCategoriaProducto)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

ALTER TABLE REGISTRO.Factura
ADD CONSTRAINT FK_PRODUCTO_FACTURA$TIENE_UN$PERSONA_CLIENTE
FOREIGN KEY (idCliente) REFERENCES PERSONA.Cliente (idCliente)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

ALTER TABLE REGISTRO.Factura
ADD CONSTRAINT FK_PRODUCTO_FACTURA$TIENE_UN$PERSONA_EMPLEADO
FOREIGN KEY (idEmpleado) REFERENCES PERSONA.Empleado (idEmpleado)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

ALTER TABLE REGISTRO.DetalleFactura
ADD CONSTRAINT FK_REGISTRO_DETALLEFACTURA$TIENE_UNA$REGISTRO_FACTURA
FOREIGN KEY (idFactura) REFERENCES REGISTRO.Factura (idFactura)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

ALTER TABLE REGISTRO.DetalleFactura
ADD CONSTRAINT FK_REGISTRO_DETALLEFACTURA$TIENE_UN$PRODUCTO_PRODUCTO
FOREIGN KEY (idProducto) REFERENCES PRODUCTO.Producto (idProducto)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------****PROCEDIMIENTOS ALMACENADOS****----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------


--PROCEDIMIENTO DE AGREGAR CLIENTE
CREATE PROCEDURE AGREGARCLIENTE @Empleado INT, @nombreCliente NVARCHAR(50), @apellidoCliente NVARCHAR(80), @identidad VARCHAR(15), @sexo CHAR(1), @telefono CHAR(9), @direccion TEXT, @correoCliente NVARCHAR(80)
AS
BEGIN TRANSACTION
	BEGIN TRY
		DECLARE @idCliente INT;
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		 BEGIN
			INSERT INTO PERSONA.Cliente(nombreCliente, apellidoCliente, identidad,sexo, telefono, direccion, correoCliente)
			VALUES (@nombreCliente, @apellidoCliente, @identidad, @sexo, @telefono, @direccion, @correoCliente);
			set @idCliente=(SELECT idCliente FROM PERSONA.Cliente WHERE identidad=@identidad);
			 INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
			VALUES ('SE A�ADI� UN CLIENTE: '+CAST(@idCliente AS varchar), 'CLIENTE', 'INSERCI�N EXITOSA', @Empleado);
		 END
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


--PROCEDIMIENTO ACTUALIZAR CLIENTE
CREATE PROCEDURE ACTUALIZARCLIENTE @Empleado INT, @nombreCliente NVARCHAR(50), @apellidoCliente NVARCHAR(50), @identidad VARCHAR(15),@estado NVARCHAR(25), @sexo CHAR(1), @telefono CHAR(9), @direccion TEXT, @correoCliente NVARCHAR(80)
AS
BEGIN TRANSACTION 
	BEGIN TRY-- se usa el transaction para evitar errores	
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			if exists(SELECT * FROM PERSONA.Cliente WHERE nombreCliente=@nombreCliente)
			BEGIN
			UPDATE PERSONA.Cliente SET nombreCliente = @nombreCliente, apellidoCliente = @apellidoCliente, identidad = @identidad , estadoCliente= @estado, sexo =  @sexo, telefono = @telefono, direccion = @direccion, correoCliente = @correoCliente WHERE identidad=@identidad;
			--UPDATE PERSONA.Cliente SET estadoCliente='ACTIVO/A' WHERE nombreCliente=@nombreCliente;
			 INSERT INTO REGISTRO.MOVIMIENTO(operacion, tabla, descripcion, encargado)
			 VALUES ('SE ACTUALIZO CLIENTE:' +@nombreCliente ,  'CLIENTE', 'ACTUALIZACI�N EXITOSA', @Empleado);
			END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


--PROCEDIMIENTO ELIMINAR CLIENTE--PROCESO DE ELIMINAR EN CLIENTES

CREATE PROCEDURE ELIMINARCLIENTE @Empleado INT, @Nombre NVARCHAR
AS
BEGIN TRANSACTION
	BEGIN TRY
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) --Debe existir ese empleado
		BEGIN
			if exists(SELECT * FROM PERSONA.Cliente WHERE nombreCliente=@Nombre) --Debe existir un cliente con ese codigo
				BEGIN
					update PERSONA.Cliente SET estadoCliente='INACTIVO/A' WHERE nombreCliente=@Nombre; --Si el cliente tiene compras no se elimina, solo se le cambia el estado
					INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
					VALUES ('SE CAMBIO ESTADO CLIENTE:'+ CAST(@Nombre AS VARCHAR) + ' A INACTIVO', 'CLIENTE', 'CLIENTE INACTIVO', @Empleado);
			    END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--PROCEDIMIENTO DE AGREGAR EMPLEADO
CREATE PROCEDURE AGREGAREMPLEADO @nombreEmpleado NVARCHAR(50), @apellidoEmpleado NVARCHAR(80), @fechaIngreso NVARCHAR(8), @puesto NVARCHAR(60), @sexo CHAR(1), @telefono CHAR(9),@direccion TEXT, @correoEmpleado NVARCHAR(80)
AS
begin TRANSACTION
	BEGIN TRY
			INSERT INTO PERSONA.Empleado(nombreEmpleado, apellidoEmpleado, fechaIngreso, puesto, sexo, telefono, direccion, correoEmpleado)
			VALUES (@nombreEmpleado, @apellidoEmpleado, @fechaIngreso, @puesto, @sexo, @telefono, @direccion, @correoEmpleado);
			 INSERT INTO REGISTRO.MOVIMIENTO(operacion, tabla, descripcion, encargado)
			 VALUES ('SE A�ADI� UN EMPLEADO: '+@nombreEmpleado, 'EMPLEADO', 'INSERCI�N EXITOSA', 0);
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO

--PROCEDIMIENTO DE ACTUALIZAR EMPLEADO 

CREATE PROCEDURE ACTUALIZAREMPLEADO  @Empleado INT, @nombreEmpleado NVARCHAR(50), @apellidoEmpleado NVARCHAR(80), @fechaIngreso NVARCHAR(8), @puesto NVARCHAR(60),@estado NVARCHAR(25), @sexo CHAR(1), @telefono CHAR(9),@direccion TEXT, @correoEmpleado NVARCHAR(80)
AS
BEGIN TRANSACTION 
	BEGIN TRY
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) 
		BEGIN
			if exists(SELECT * FROM PERSONA.Empleado WHERE nombreEmpleado=@nombreEmpleado)
			BEGIN
			UPDATE PERSONA.EMPLEADO SET nombreEmpleado = @nombreEmpleado, apellidoEmpleado = @apellidoEmpleado,fechaIngreso = @fechaIngreso, puesto = @puesto, estadoEmpleado = @estado ,sexo = @sexo, telefono = @telefono, direccion = @direccion, correoEmpleado = @correoEmpleado WHERE nombreEmpleado=@nombreEmpleado;
			 INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
			 VALUES ('SE ACTUALIZO EMPLEADO:' + CAST(@nombreEmpleado AS VARCHAR),  'EMPLEADO', 'ACTUALIZACI�N EXITOSA', @Empleado);
			END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


--PROCEDIMIENTO ELIMINAR EMPLEADO
CREATE PROCEDURE ELIMINAREMPLEADO @Empleado INT, @nombre NVARCHAR(50)
AS
BEGIN TRANSACTION
	BEGIN TRY
		IF EXISTS (SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) 
		BEGIN
			if exists(SELECT * FROM PERSONA.Empleado WHERE nombreEmpleado=@nombre) 
			BEGIN
					update PERSONA.Empleado SET estadoEmpleado='INACTIVO/A' WHERE nombreEmpleado=@nombre; 
					INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
					VALUES ('SE CAMBIO ESTADO EMPLEADO:'+ CAST(@nombre AS VARCHAR) + ' A INACTIVO', 'EMPLEADO', 'EMPLEADO INACTIVO', @Empleado);
			END		
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--PROCEDIMIENTO DE AGREGAR USUARIO	
CREATE PROCEDURE AGREGARUSUARIO  @nombreUsuario NVARCHAR(25), @passwordUsuario NVARCHAR(12), @nivelUsuario VARCHAR(15)
AS
begin TRANSACTION
	BEGIN TRY
		declare @idUsuario INT;
			INSERT INTO PERSONA.Usuario(nombreUsuario, passwordUsuario, nivelUsuario)
			VALUES (@nombreUsuario, @passwordUsuario, @nivelUsuario);
			set @idUsuario=(SELECT idUsuario FROM PERSONA.Usuario WHERE nombreUsuario= @nombreUsuario);
			 INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
			VALUES ('SE A�ADI� UN USUARIO: '+CAST(@idUsuario AS varchar), 'USUARIO', 'INSERCI�N EXITOSA',0);
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


--PROCEDIMIENTO DE ACTUALIZAR USUARIO	

CREATE PROCEDURE ACTUALIZARUSUARIO @Empleado INT, @nombreUsuario NVARCHAR(25), @passwordUsuario NVARCHAR(12),@estado NVARCHAR(25), @nivelUsuario VARCHAR(15)
AS
BEGIN TRANSACTION 
	BEGIN TRY-- se usa el transaction para evitar errores	
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			if exists(SELECT * FROM PERSONA.Usuario WHERE nombreUsuario=@nombreUsuario)
			BEGIN
			UPDATE PERSONA.Usuario SET nombreUsuario = @nombreUsuario, passwordUsuario = @passwordUsuario, estadoUsuario = @estado, nivelUsuario = @nivelUsuario WHERE nombreUsuario=@nombreUsuario;
			 INSERT INTO REGISTRO.MOVIMIENTO(operacion, tabla, descripcion, encargado)
			 VALUES ('SE ACTUALIZO EL USUARIO:' + CAST(@nombreUsuario AS VARCHAR),  'USUARIO', 'ACTUALIZACI�N EXITOSA', @Empleado);
			END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


--PROCEDIMIENTO DE ELIMINAR USUARIO	
CREATE PROCEDURE ELIMINARUSUARIO @Empleado INT, @nombre NVARCHAR(50)
AS
BEGIN TRANSACTION
	BEGIN TRY
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) --Debe existir ese empleado
		BEGIN
			if exists(SELECT * FROM PERSONA.Usuario WHERE nombreUsuario=@nombre) --Debe existir un cliente con ese codigo
			BEGIN
					update PERSONA.Usuario SET estadoUsuario='INACTIVO/A' WHERE nombreUsuario=@nombre; 
					INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
					VALUES ('SE CAMBIO ESTADO USUARIO:'+ CAST(@nombre AS VARCHAR) + ' A INACTIVO', 'USUARIO', ' INACTIVO', @Empleado);
			END   
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--PROCEDIMIENTO DE AGREGAR CATEGORIA PRODUCTO
CREATE PROCEDURE AGREGARCATEGORIAPRODUCTO @Empleado INT, @nombreCategoria NVARCHAR(30)
AS
begin TRANSACTION
	BEGIN TRY
		declare @idCategoriaProducto INT;
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			INSERT INTO PRODUCTO.CategoriaProducto(nombreCategoria)
			VALUES (@nombreCategoria);
			set @idCategoriaProducto=(SELECT idCategoriaProducto FROM PRODUCTO.CategoriaProducto WHERE nombreCategoria= @nombreCategoria);
			 INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
			VALUES ('SE A�ADI� UNA CATEGORIA DE PRODUCTO: '+@nombreCategoria, 'CATEGORIAPRODUCTO', 'INSERCI�N EXITOSA', @Empleado);
		END
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO

--PROCEDIMIENTO DE ACTUALIZAR CATEGORIA DEL PRODUCTO	
CREATE PROCEDURE ACTUALIZARCATEGORIAPRODUCTO @Empleado INT, @nombre NVARCHAR(30),@Estado NVARCHAR(20)  
AS
BEGIN TRANSACTION 
	BEGIN TRY-- se usa el transaction para evitar errores	
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			if exists(SELECT * FROM PRODUCTO.CategoriaProducto WHERE nombreCategoria=@nombre)
			BEGIN
			UPDATE PRODUCTO.CategoriaProducto SET nombreCategoria = @nombre, estadoCategoriaProducto = @Estado WHERE nombreCategoria=@nombre;
			 INSERT INTO REGISTRO.MOVIMIENTO(operacion, tabla, descripcion, encargado)
			 VALUES ('SE ACTUALIZO UNA CATEGORIA:' + CAST(@nombre AS VARCHAR),  'CATEGORIAPRODUCTO', 'ACTUALIZACI�N EXITOSA', @Empleado);
			END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


--PROCEDIMIENTO DE ELIMINAR CATEGORIA DE PRODUCTO
CREATE PROCEDURE ELIMINARCATEGORIAPRODUCTO @Empleado INT, @nombre NVARCHAR(30)
AS
BEGIN TRANSACTION
	BEGIN TRY
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) --Debe existir ese empleado
		BEGIN
			if exists(SELECT * FROM PRODUCTO.CategoriaProducto WHERE nombreCategoria=@nombre) --Debe existir un cliente con ese codigo
			BEGIN
				update PRODUCTO.CategoriaProducto SET estadoCategoriaProducto='INACTIVO/A' WHERE nombreCategoria=@nombre;
					INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
					VALUES ('SE CAMBIO ESTADO CATEGORIA PRODUCTO:'+ CAST(@nombre AS VARCHAR) + ' A INACTIVO', 'CATEGORIAPRODUCTO', ' INACTIVO', @Empleado);
			END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--PROCEDIMIENTO DE AGREGAR PRODUCTO	
CREATE PROCEDURE AGREGARPRODUCTO @Empleado INT, @idProveedor INT, @idCategoriaProducto INT, @nombreProducto NVARCHAR(50), @stock INT, @precio DECIMAL(10,2), @marca NVARCHAR(40) ,@fechaCaducidad DATE
AS
begin TRANSACTION
	BEGIN TRY
		declare @idProducto INT;
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			INSERT INTO PRODUCTO.Producto(idProveedor,idCategoriaProducto, nombreProducto, stock, precio, marca, fechaCaducidad)
			VALUES (@idProveedor, @idCategoriaProducto,@nombreProducto, @stock, @precio,@marca, @fechaCaducidad);
			set @idProducto=(SELECT idProducto FROM PRODUCTO.Producto WHERE nombreProducto= @nombreProducto);
			 INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
			VALUES ('SE A�ADI� UN PRODUCTO:'+CAST(@idProducto AS VARCHAR), 'PRODUCTO', 'INSERCI�N EXITOSA', @Empleado);
		END
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO



--PROCEDIMIENTO DE ACTUALIZAR PRODUCTO	
CREATE PROCEDURE ACTUALIZARPRODUCTO @Empleado INT,@estado NVARCHAR(25), @idProveedor INT, @idCategoriaProducto INT, @nombreProducto NVARCHAR(50), @stock INT, @precio DECIMAL(10,2), @marca NVARCHAR(40) ,@fechaCaducidad DATE
AS
BEGIN TRANSACTION 
	BEGIN TRY-- se usa el transaction para evitar errores	
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			if exists(SELECT * FROM PRODUCTO.Producto WHERE nombreProducto=@nombreProducto)
			BEGIN
			UPDATE PRODUCTO.Producto SET idProveedor= @idProveedor,idCategoriaProducto = @idCategoriaProducto, nombreProducto = @nombreProducto, stock = @stock, precio = @precio, marca = @marca, fechaCaducidad = @fechaCaducidad WHERE nombreProducto=@nombreProducto;

			 INSERT INTO REGISTRO.MOVIMIENTO(operacion, tabla, descripcion, encargado)
			 VALUES ('SE ACTUALIZO EL PRODUCTO:' + CAST(@nombreProducto AS VARCHAR),  'PRODUCTO', 'ACTUALIZACI�N EXITOSA', @Empleado);
			END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


---------------------------------------------------------------------------------------------------------------------------
--PROCEDIMIENTO DE ELIMINAR PRODUCTO	
CREATE PROCEDURE ELIMINARPRODUCTO @Empleado INT, @nombre INT
AS
BEGIN TRANSACTION
	BEGIN TRY
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) --Debe existir ese empleado
		BEGIN

			if exists(SELECT * FROM PRODUCTO.Producto WHERE nombreProducto=@nombre) --Debe existir un cliente con ese codigo
			BEGIN
				update PRODUCTO.Producto SET estadoProducto='INACTIVO/A' WHERE nombreProducto=@nombre;
				INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
				VALUES ('SE CAMBIO ESTADO PRODUCTO:'+ CAST(@nombre AS VARCHAR) + ' A INACTIVO', 'PRODUCTO', ' INACTIVO', @Empleado);
			END

		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--PROCEDIMIENTO DE AGREGAR PROVEEDOR
CREATE PROCEDURE AGREGARPROVEEDOR @Empleado INT, @nombreProveedor NVARCHAR(50), @telefonoProveedor CHAR(9), @celularproveedor CHAR(9), @direccionProveedor TEXT, @descripcionProveedor TEXT, @correoProveedor NVARCHAR(80)
AS
begin TRANSACTION
	BEGIN TRY
		declare @idProveedor INT;
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			INSERT INTO PRODUCTO.Proveedor(nombreProveedor, telefonoProveedor, celularProveedor, direccionProveedor, descripcionProveedor, correoProveedor)
			VALUES (@nombreProveedor, @telefonoProveedor, @celularproveedor, @direccionProveedor, @descripcionProveedor, @correoProveedor);
			set @idProveedor=(SELECT idProveedor FROM PRODUCTO.Proveedor WHERE nombreProveedor=@nombreProveedor);
			 INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
			VALUES ('SE A�ADI� UN PROVEEDOR: '+CAST(@idProveedor AS varchar), 'PROVEEDOR', 'INSERCI�N EXITOSA', @Empleado);
		END
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--PROCEDIMIENTO DE ACTUALIZAR PROVEEDOR	

CREATE PROCEDURE ACTUALIZARPROVEEDOR @Empleado INT, @nombreProveedor NVARCHAR(50), @telefonoProveedor CHAR(9), @celularproveedor CHAR(9), @direccionProveedor TEXT, @descripcionProveedor TEXT, @estado NVARCHAR(20), @correoProveedor NVARCHAR(80)
AS
BEGIN TRANSACTION 
	BEGIN TRY-- se usa el transaction para evitar errores	
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado)
		BEGIN
			if exists(SELECT * FROM PRODUCTO.Proveedor WHERE nombreProveedor=@nombreProveedor)
			BEGIN
			UPDATE PRODUCTO.Proveedor SET nombreProveedor= @nombreProveedor,telefonoProveedor = @telefonoProveedor, celularproveedor = @celularproveedor, direccionProveedor = @direccionProveedor, descripcionProveedor  = @descripcionProveedor ,estadoProveedor=@estado, correoProveedor = @correoProveedor WHERE nombreProveedor=@nombreProveedor;
			 INSERT INTO REGISTRO.MOVIMIENTO(operacion, tabla, descripcion, encargado)
			 VALUES ('SE ACTUALIZO EL PROVEEDOR:' , 'PROVEEDOR', 'ACTUALIZACI�N EXITOSA', @Empleado);
			END
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO

---------------------------------------------------------------------------------------------------------------------------
--PROCEDIMIENTO DE ELIMINAR PROVEEDOR	
CREATE PROCEDURE ELIMINARPROVEEDOR @Empleado INT, @nombre NVARCHAR(50)
AS
BEGIN TRANSACTION
	BEGIN TRY
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) --Debe existir ese empleado
		BEGIN

			if exists(SELECT * FROM PRODUCTO.Proveedor WHERE nombreProveedor=@nombre) 
			BEGIN
				update PRODUCTO.Proveedor SET estadoProveedor='INACTIVO/A' WHERE nombreProveedor=@nombre;
				INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado)
				VALUES ('SE CAMBIO ESTADO PROVEEDOR:'+ ' A INACTIVO', 'PROVEEDOR', ' INACTIVO', @Empleado);
			END

		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--AGREGAR FACTURA
CREATE PROCEDURE AGREGARFACTURA @Empleado INT, @IdCliente INT 
AS
begin TRANSACTION
	BEGIN TRY
		--DECLARE @idFactura INT;
		    IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE idEmpleado=@Empleado) 
		     BEGIN
			  IF EXISTS(SELECT * FROM PERSONA.Cliente WHERE idCliente=@IdCliente)
		       BEGIN

			  -- DECLARE @CONTADOR INT;
			   INSERT INTO REGISTRO.Factura (idCliente, idEmpleado) 
			   VALUES (@IdCliente, @Empleado);

			   --SET @idFactura=(SELECT idFactura FROM Registro.Factura WHERE idCliente=@IdCliente);
			   --INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado) 
			   --VALUES ('SE AGREGO UNA FACTURA: ' + CAST (@IdFactura AS VARCHAR) + ' AL CLIENTE : ' + CAST (@IdCliente AS VARCHAR) ,'FACTURA', 'INSERT CORRECTO', @Empleado);

			   --IF ISNULL((SELECT vecesCompra FROM PERSONA.Cliente WHERE IdCliente=@IdCliente),0)=0 
			   --BEGIN
				--SET @CONTADOR=0;
			   --END
			    --ELSE
			   --BEGIN
				--	SET @CONTADOR=(SELECT vecesCompra FROM PERSONA.Cliente WHERE idCliente=@IdCliente); 
			   --END
			   --UPDATE PERSONA.Cliente SET  vecesCompra=@CONTADOR+1 WHERE idCliente=@idCliente; 
			   --IF (SELECT estadoCliente FROM PERSONA.Cliente WHERE idCliente=@idCliente)='INACTIVO/A' 
			--   BEGIN
			--	UPDATE PERSONA.Cliente SET estadoCliente='ACTIVO/A' WHERE idCliente=@idCliente;
			  -- END
		 END
		END
		COMMIT
END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO

-----PROCEDIMIENTO ACTUALIZAR FACTURA
CREATE PROCEDURE ACTUALIZARFACTURA  @IdFactura INT , @total DECIMAL(10,2)
AS
BEGIN TRANSACTION 
	BEGIN TRY
			IF exists(SELECT * FROM REGISTRO.Factura WHERE idFactura=@IdFactura)
			BEGIN
			UPDATE REGISTRO.Factura SET total = @total  WHERE idFactura=@IdFactura;
			 /*INSERT INTO REGISTRO.MOVIMIENTO(operacion, tabla, descripcion, encargado)
			 VALUES ('SE ACTUALIZO LA FACTURA:' , 'FACTURA', 'ACTUALIZACI�N EXITOSA', @Empleado);*/
			END
		
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--AGREGAR DETALLE DE FACTURA
CREATE PROCEDURE AGREGARDETALLEFACTURA @EMPLEADO INT, @ID_PRODUCTO INT,@IDFACTURA INT, @CANTIDAD INT, @TOTAL INT
AS
begin TRANSACTION
	BEGIN TRY
		IF EXISTS(SELECT * FROM PRODUCTO.Producto WHERE idProducto=@ID_PRODUCTO) 
		BEGIN
		IF EXISTS(SELECT * FROM REGISTRO.Factura WHERE IdFactura=@IDFACTURA) 
		BEGIN
		IF EXISTS(SELECT * FROM PERSONA.Empleado WHERE IdEmpleado=@EMPLEADO) 
		BEGIN
			IF @CANTIDAD<=(SELECT stock FROM PRODUCTO.Producto WHERE idProducto=@ID_PRODUCTO) 
			BEGIN
				DECLARE @PRECIO MONEY,
				@NOMBRE NVARCHAR(50),
				@CONTADOR INT,
				@STOCKACTU INT;
				SET @PRECIO=(SELECT Precio FROM PRODUCTO.Producto WHERE IdProducto=@ID_PRODUCTO); 
				SET @NOMBRE=(SELECT nombreProducto FROM PRODUCTO.Producto WHERE idProducto=@ID_PRODUCTO);
				INSERT INTO REGISTRO.DetalleFactura(IdFactura, IdProducto, Cantidad, Total) 
				VALUES (@IDFACTURA, @ID_PRODUCTO, @CANTIDAD, @TOTAL);
				INSERT INTO REGISTRO.Movimiento(operacion, tabla, descripcion, encargado) 
				VALUES ('SE AGREGO UN PRODUCTO A LA FACTURA', 'FACTURA', 'INSERCION EXITOSA', @EMPLEADO);
				SET @CONTADOR=(SELECT stock FROM PRODUCTO.Producto WHERE idProducto=@ID_PRODUCTO); 
				SET @STOCKACTU=@CONTADOR-@CANTIDAD; 
				UPDATE PRODUCTO.Producto SET Stock=@STOCKACTU WHERE idProducto=@ID_PRODUCTO; 
			END
		END
		END		
		END
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO

/*
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------***INSERCION DE DATOS****------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------


--================================================================EMPLEADO(INSERCION)================================================================================

--Agregar un Empleado en la tabla REGISTROS.Empleado(nombreEmpleado, apellidoEmpleado, fechaIngreso, puesto, sexo, telefono, direccion, correoEmpleado)

EXEC AGREGAREMPLEADO 'Bryan', 'alee', '09/09/99', 'Gerente', 'M', '96878765','San Miguel','Mfr@gmail.com'
go

EXEC ACTUALIZAREMPLEADO  01, 02, 'ned1', 'Flanders', '09/09/99', 'Gerente', 'M', '96878765','San Miguel','Mfr@gmail.com'
go

EXEC ELIMINAREMPLEADO 02,01
go


--================================================================CLIENTE(INSERCION)================================================================================

--Agregar un Cliente en la tabla REGISTROS.Cliente (Identidad del empleado, nombreCliente, apellidoCliente, identidad, sexo, telefono, direccion, correoCliente)

EXEC AGREGARCLIENTE 01,'carlos', 'manuel', '25455555', 'M', '965215', 'tegus', 'Crishy@yahoo.com'
go

EXEC ACTUALIZARCLIENTE 04,'Peperfr', 'Hernand�zz', '0313199900418','M', '97895670', 'Comayagua', 'Crishy@yahoo.com' 
go

EXEC ELIMINARCLIENTE 01,01
go

select * from PERSONA.Cliente 
go

--================================================================USUARIO(INSERCION)================================================================================

--Agregar un Cliente en la tabla REGISTROS.Usuario (Identidad del empleado, nombre del usuario, password, nivel del usuario)

EXEC AGREGARUSUARIO 'Bryan', 'alee', 'administrador'
go

EXEC ACTUALIZARUSUARIO 01,01,'usu2', 'arroz09', 'empleado'
go

EXEC ELIMINARUSUARIO 01,01 
go


--================================================================USUARIO(INSERCION)================================================================================

--Agregar un Cliente en la tabla PRODUCTO.CaterogoriaProducto (Identidad del empleado, nombre de la categoria)


EXEC AGREGARCATEGORIAPRODUCTO  01,'alimentos'
go

EXEC  ACTUALIZARCATEGORIAPRODUCTO 01,01,'Alimentos Procesados'
go

EXEC ELIMINARCATEGORIAPRODUCTO 01, 01 
go


--================================================================PROVEEDOR(INSERCION)================================================================================

--Agregar un Proveedor en la tabla PRODUCTO.Producto(empleado, nombre proveedor, telefono, celular, ubicacion, descripcion, correo)

EXEC AGREGARPROVEEDOR 01,' carnes', '25566', '2526', 'San Sulas', 'clase', 'Lopez@gmail.com'
go

EXEC ACTUALIZARPROVEEDOR  01, 01,'Distribuidora Hernandez', '27730987', '98765432', 'San Pedro Sula', 'Excelente', 'Lopez@gmail.com'
go


EXEC ELIMINARPROVEEDOR 01,01
go



--================================================================PRODUCTO(INSERCION)================================================================================

--Agregar un Producto en la tabla PRODUCTO.Producto(empleado,id Proveedor, id categoria Producto, nombreProducto,stock, precio, marca, fecha de Caducidad)

EXEC AGREGARPRODUCTO 01,02,02,'carnes', 25, 45.00, 'corral', '07/06/01'
go

EXEC ACTUALIZARPRODUCTO  01, 01,01,01 ,'Pasta Italiana', 14, 15.00, 'Mi Pasta', '12/01/02'
go


EXEC ELIMINARPRODUCTO 01,01
go


--================================================================DETALLE DE FACTURA(INSERCION)================================================================================

--Agregar un Detalle de Factura en la tabla REGISTRO.DetalleFactura(IdEmpleado,IdProducto, IdFactura , Cantidad, Total)

EXEC AGREGARDETALLEFACTURA 01,01,01,3,12
go

EXEC AGREGARDETALLEFACTURA 01,01,01,6,112
go

--Agregar Factura (IdEmpleado, IdCliente)

EXEC AGREGARFACTURA 2,1
go




--================================================================FACTURA(INSERCION)================================================================================

--Agregar una Factura en la tabla REGISTRO.Factura (Identidad del empleado, nombre del usuario, password, nivel del usuario)

/*
SELECT * FROM PERSONA.Cliente
GO

SELECT * FROM PERSONA.Empleado
GO

SELECT * FROM PRODUCTO.CategoriaProducto
GO

SELECT * FROM PRODUCTO.Proveedor
GO

SELECT * FROM PRODUCTO.Producto
GO

SELECT * from REGISTRO.Factura
GO


SELECT * FROM REGISTRO.DetalleFactura
GO

SELECT * FROM REGISTRO.Movimiento
GO
SELECT * FROM PERSONA.Usuario
GO
CREATE TRIGGER calculartotalfactura

select SUM(total) as total from REGISTRO.DetalleFactura where idFactura =6

select * from REGISTRO.DetalleFactura where idFactura = 12 
*/
*/