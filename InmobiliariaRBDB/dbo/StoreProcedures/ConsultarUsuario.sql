CREATE PROCEDURE [dbo].[ConsultarUsuario]
	@i_nombre_usuario	varchar(30) = NULL
AS
	
SELECT	*
FROM	USUARIO
WHERE	USERNAME = ISNULL(@i_nombre_usuario, USERNAME)
AND		ESTADO = 1

RETURN 0