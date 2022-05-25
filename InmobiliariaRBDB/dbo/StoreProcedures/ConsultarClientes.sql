CREATE PROCEDURE [dbo].[ConsultarClientes]
	@i_id_cliente INT = NULL
AS

SELECT	* 
FROM	dbo.CLIENTE 
WHERE	IDCLIENTE = ISNULL(@i_id_cliente, IDCLIENTE)

RETURN 0
