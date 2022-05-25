CREATE PROCEDURE [dbo].[EliminarPropietario]
	@i_id_propietario int
AS

UPDATE	dbo.PROPIETARIO
SET		ESTADOPROPIETARIO = 0
WHERE	IDPROPIETARIO = @i_id_propietario

RETURN 0
