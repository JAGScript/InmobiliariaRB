CREATE PROCEDURE [dbo].[ActualizarPropiedad]
    @i_id_propiedad         int,
	@i_id_tipo_propiedad    int,
    @i_id_provincia         int,
    @i_precio               money = null,
    @i_id_usuario           int = null,
    @i_estado               bit
AS

UPDATE  dbo.PROPIEDAD
SET     IDTIPOPROPIEDAD = @i_id_tipo_propiedad,
        IDPROVINCIA     = @i_id_provincia,
        PRECIO          = @i_precio,
        IDUSUARIO       = @i_id_usuario,
        ESTADOPROPIEDAD = @i_estado
WHERE   IDPROPIEDAD     = @i_id_propiedad

RETURN 0
