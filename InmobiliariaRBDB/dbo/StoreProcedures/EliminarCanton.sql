CREATE PROCEDURE [dbo].[EliminarCanton]
	@i_id_canton        INT
AS

UPDATE  dbo.CANTON
SET     ESTADOCANTON    = 0
WHERE   IDCANTON        = @i_id_canton

RETURN 0
