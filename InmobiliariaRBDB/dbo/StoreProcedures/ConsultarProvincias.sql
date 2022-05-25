CREATE PROCEDURE [dbo].[ConsultarProvincias]
	@i_id_provincia INT = NULL
AS

SELECT	* 
FROM	dbo.PROVINCIA 
WHERE	IDPROVINCIA = ISNULL(@i_id_provincia, IDPROVINCIA)

RETURN 0
