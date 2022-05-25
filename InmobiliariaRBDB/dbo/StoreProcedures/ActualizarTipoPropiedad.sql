CREATE PROCEDURE [dbo].[ActualizarTipoPropiedad]
	@i_id_tipo     INT,
    @i_nombre      VARCHAR(100),
    @i_estado      BIT
AS

UPDATE  dbo.TIPO_PROPIEDAD
SET     NOMBRETIPOPROPIEDAD     = ISNULL(@i_nombre, NOMBRETIPOPROPIEDAD),
        ESTADOTIPOPROPIEDAD     = ISNULL(@i_estado, ESTADOTIPOPROPIEDAD)
WHERE   IDTIPOPROPIEDAD         = @i_id_tipo

RETURN 0
