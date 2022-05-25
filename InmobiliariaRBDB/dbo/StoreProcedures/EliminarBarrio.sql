CREATE PROCEDURE [dbo].[EliminarBarrio]
	@i_id_barrio int
AS

UPDATE  dbo.BARRIO
SET     ESTADOBARRIO = 0
WHERE   IDBARRIO     = @i_id_barrio

RETURN 0