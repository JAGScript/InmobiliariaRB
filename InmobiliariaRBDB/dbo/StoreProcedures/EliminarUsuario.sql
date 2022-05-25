CREATE PROCEDURE [dbo].[EliminarUsuario]
	@i_id_usuario INT
AS

UPDATE	dbo.USUARIO
SET		ESTADO		= 0
WHERE	IDUSUARIO	= @i_id_usuario

RETURN 0
