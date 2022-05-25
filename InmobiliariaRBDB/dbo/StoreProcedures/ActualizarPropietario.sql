CREATE PROCEDURE [dbo].[ActualizarPropietario]
    @i_id_propietario   int,
	@i_nombre           varchar(100),
    @i_direccion        varchar(200),
    @i_celular          varchar(10),
    @i_correo           varchar(100),
    @i_estado           bit
AS

UPDATE  dbo.PROPIETARIO
SET     NOMBREPROPIETARIO = @i_nombre,
        DIRECCIONPROPIETARIO = @i_direccion,
        CELULARPROPIETARIO = @i_celular,
        CORRREOPROPIETARIO = @i_correo,
        ESTADOPROPIETARIO = @i_estado
WHERE   IDPROPIETARIO = @i_id_propietario

RETURN 0
