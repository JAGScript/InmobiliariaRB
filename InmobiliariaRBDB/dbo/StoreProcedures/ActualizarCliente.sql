CREATE PROCEDURE [dbo].[ActualizarCliente]
	@i_id_cliente       INT,
    @i_nombre           VARCHAR(100),
    @i_identificacion   VARCHAR(10),
    @i_direccion        VARCHAR(200),
    @i_celular          VARCHAR(10),
    @i_correo           VARCHAR(100),
    @i_id_asesor        INT,
    @i_estado           BIT
AS

UPDATE  dbo.CLIENTE
SET     NOMBRECLIENTE           = ISNULL(@i_nombre, NOMBRECLIENTE),
        IDENTIFICACIONCLIENTE   = ISNULL(@i_identificacion, IDENTIFICACIONCLIENTE),
        DIRECCIONCLIENTE        = ISNULL(@i_direccion, DIRECCIONCLIENTE),
        CELULARCLIENTE          = ISNULL(@i_celular, CELULARCLIENTE),
        CORREOCLIENTE           = ISNULL(@i_correo, CORREOCLIENTE),
        ASESOR                  = ISNULL(@i_id_asesor, ASESOR),
        ESTADOCLIENTE           = ISNULL(@i_estado, ESTADOCLIENTE)
WHERE   IDCLIENTE = @i_id_cliente

RETURN 0
