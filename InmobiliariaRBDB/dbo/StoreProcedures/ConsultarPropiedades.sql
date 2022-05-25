﻿CREATE PROCEDURE [dbo].[ConsultarPropiedades]
	@i_id_propiedad int = null
AS

SELECT	PROPIEDAD.*,
		TIPO_PROPIEDAD.NOMBRETIPOPROPIEDAD,
		PROVINCIA.NOMBREPROVINCIA
FROM	PROPIEDAD
		JOIN TIPO_PROPIEDAD ON PROPIEDAD.IDTIPOPROPIEDAD = TIPO_PROPIEDAD.IDTIPOPROPIEDAD
		JOIN PROPIETARIO ON PROPIEDAD.IDPROPIETARIO = PROPIETARIO.IDPROPIETARIO
		JOIN PROVINCIA ON PROPIEDAD.IDPROVINCIA = PROVINCIA.IDPROVINCIA
WHERE	PROPIEDAD.IDPROPIEDAD = ISNULL(@i_id_propiedad, PROPIEDAD.IDPROPIEDAD)
ORDER BY PROPIEDAD.IDPROPIEDAD

RETURN 0