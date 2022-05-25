CREATE PROCEDURE [dbo].[ConsultarRoles]
	@i_id_rol_seguridad		int = NULL
AS
	
SELECT	*
FROM	dbo.ROL
WHERE	IDROL = ISNULL(@i_id_rol_seguridad, IDROL)

RETURN 0