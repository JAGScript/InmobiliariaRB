CREATE PROCEDURE [dbo].[ConsultarUsuarios]
	@i_id_usuario		int = NULL
AS
	
SELECT	*
FROM	dbo.USUARIO
WHERE	IDUSUARIO = ISNULL(@i_id_usuario, IDUSUARIO)

RETURN 0