CREATE PROCEDURE [dbo].[ActualizarTransaccion]
	@i_id_transaccion			int,
	@i_descripcion				varchar(300) = NULL,
	@i_estado					bit = NULL,
	@i_id_usuario_modificacion	int
AS

UPDATE	dbo.TRANSACCION
SET		ESTADO = ISNULL(@i_estado, Estado),
		DESCRIPCION = ISNULL(@i_descripcion, Descripcion),
		IDUSUARIOMODIFICACION = @i_id_usuario_modificacion,
		FECHAMODIFICACION = GETDATE()
WHERE	IDTRANSACCION = @i_id_transaccion

RETURN 0