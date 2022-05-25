CREATE PROCEDURE [dbo].[EliminarTransaccionRolSeguridad]
	@i_id_transaccion_rol_seguridad		int
AS

DELETE FROM dbo.TRANSACCIONROL
WHERE	IDTRANSACCIONROL = @i_id_transaccion_rol_seguridad

RETURN 0