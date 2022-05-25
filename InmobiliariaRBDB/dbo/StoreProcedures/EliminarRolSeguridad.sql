CREATE PROCEDURE [dbo].[EliminarRolSeguridad]
	@i_id_rol_seguridad		int,
	@i_id_usuario			int
AS

UPDATE	ROL
SET		ESTADOROL = 0
WHERE	IDROL = @i_id_rol_seguridad

RETURN 0