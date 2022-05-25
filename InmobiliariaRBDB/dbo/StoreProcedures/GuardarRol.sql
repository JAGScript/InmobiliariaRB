CREATE PROCEDURE [dbo].[GuardarRol]
	@i_nombre			varchar(30),
	@o_id_rol_seguridad	int out
AS

INSERT INTO ROL
(
	NOMBREROL,
	ESTADOROL
)
VALUES
(
	@i_nombre,
	1
)

SET @o_id_rol_seguridad = SCOPE_IDENTITY()

RETURN 0