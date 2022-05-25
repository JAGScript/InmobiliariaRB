CREATE PROCEDURE [dbo].[GuardarPropietario]
	@i_nombre       varchar(100),
    @i_direccion    varchar(200),
    @i_celular      varchar(10),
    @i_correo       varchar(100),
    @i_estado       bit
AS

INSERT INTO dbo.PROPIETARIO
(
    NOMBREPROPIETARIO,
    DIRECCIONPROPIETARIO,
    CELULARPROPIETARIO,
    CORRREOPROPIETARIO,
    ESTADOPROPIETARIO
)
VALUES
(
    @i_nombre,
    @i_direccion,
    @i_celular,
    @i_correo,
    @i_estado
)

RETURN 0
