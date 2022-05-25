CREATE PROCEDURE [dbo].[EliminarProvincia]
	@i_id_provincia     INT
AS

UPDATE  dbo.PROVINCIA
SET     ESTADOPROVINCIA     = 0
WHERE   IDPROVINCIA         = @i_id_provincia

RETURN 0
