CREATE PROCEDURE [dbo].[ActualizarRolSeguridad]
	@i_id_rol_seguridad		int,
	@i_nombre				varchar(30) = NULL,
	@i_descripcion			varchar(300) = NULL,
	@i_estado				bit = NULL,
	@i_id_usuario			int
AS

UPDATE	ROL
SET		NOMBREROL = ISNULL(@i_nombre, NOMBREROL),
		ESTADOROL = ISNULL(@i_estado, ESTADOROL)
WHERE	IDROL = @i_id_rol_seguridad

RETURN 0