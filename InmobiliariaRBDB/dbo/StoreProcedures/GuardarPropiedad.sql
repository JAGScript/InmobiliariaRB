CREATE PROCEDURE [dbo].[GuardarPropiedad]
	@i_id_tipo_propiedad    int,
    @i_id_provincia         int,
    @i_precio               money = null,
    @i_id_usuario           int = null,
    @i_estado               bit
AS
INSERT INTO dbo.PROPIEDAD
(
    IDCARACTERISTICA,
    IDPROVINCIA,
    IDTIPOPROPIEDAD,
    IDPROPIETARIO,
    IDUSUARIO,
    PRECIO,
    FECHAREGISTROPROPIEDAD,
    ESTADOPROPIEDAD
)
VALUES
(
    0,
    @i_id_provincia,
    @i_id_tipo_propiedad,
    0,
    @i_id_usuario,
    @i_precio,
    GETDATE(),
    @i_estado
)
RETURN 0