CREATE PROCEDURE [dbo].[ConsultarTransacciones]
	@i_id_transaccion		int = NULL
AS
	
SELECT	*
FROM	dbo.TRANSACCION
WHERE	IDTRANSACCION = ISNULL(@i_id_transaccion, IDTRANSACCION)

RETURN 0