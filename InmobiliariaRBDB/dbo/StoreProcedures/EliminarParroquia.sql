CREATE PROCEDURE [dbo].[EliminarParroquia]
	@i_id_parroquia int
AS

UPDATE  dbo.PARROQUIA
SET     ESTADOPARROQUIA = 0
WHERE   IDPARROQUIA     = @i_id_parroquia

RETURN 0
