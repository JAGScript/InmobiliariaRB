CREATE PROCEDURE [dbo].[GuardarCliente]
	@i_nombre           VARCHAR(100),
    @i_identificacion   VARCHAR(10),
    @i_direccion        VARCHAR(200),
    @i_celular          VARCHAR(10),
    @i_correo           VARCHAR(100),
    @i_id_asesor        INT,
    @i_estado           BIT
AS

INSERT INTO dbo.CLIENTE
(
    IDENTIFICACIONCLIENTE,
    NOMBRECLIENTE,
    DIRECCIONCLIENTE,
    CELULARCLIENTE,
    CORREOCLIENTE,
    ASESOR,
    ESTADOCLIENTE
)
VALUES
(
    @i_identificacion,
    @i_nombre,
    @i_direccion,
    @i_celular,
    @i_correo,
    @i_id_asesor,
    1
)

RETURN 0
