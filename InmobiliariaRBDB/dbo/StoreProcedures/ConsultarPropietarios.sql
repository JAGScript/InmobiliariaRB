CREATE PROCEDURE [dbo].[ConsultarPropietarios]
	@i_id_propietario int = null
AS

SELECT	*
FROM	PROPIETARIO
ORDER BY IDPROPIETARIO

RETURN 0
