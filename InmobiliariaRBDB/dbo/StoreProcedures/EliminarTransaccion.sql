CREATE PROCEDURE [dbo].[EliminarTransaccion]
	@i_id_transaccion			int,
	@i_id_usuario_modificacion	int
AS

UPDATE	dbo.TRANSACCION
SET		ESTADO = 0,
		IDUSUARIOMODIFICACION = @i_id_usuario_modificacion,
		FECHAMODIFICACION = GETDATE()
WHERE	IDTRANSACCION = @i_id_transaccion

RETURN 0