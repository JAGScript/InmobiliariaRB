CREATE PROCEDURE [dbo].[EliminarPropiedad]
	@i_id_propiedad int
AS

UPDATE  dbo.PROPIEDAD
SET     ESTADOPROPIEDAD = 0
WHERE   IDPROPIEDAD     = @i_id_propiedad

RETURN 0
