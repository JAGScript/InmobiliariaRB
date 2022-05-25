CREATE PROCEDURE [dbo].[EliminarCliente]
	@i_id_cliente INT
AS

UPDATE	dbo.CLIENTE
SET		ESTADOCLIENTE = 0
WHERE	IDCLIENTE = @i_id_cliente

RETURN 0
