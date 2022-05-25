CREATE PROCEDURE [dbo].[GuardarTipoPropiedad]
	@i_nombre	VARCHAR(100),
    @i_estado	BIT
AS

INSERT INTO dbo.TIPO_PROPIEDAD
(
    NOMBRETIPOPROPIEDAD,
    ESTADOTIPOPROPIEDAD
)
VALUES
(
    @i_nombre,
    @i_estado
)

RETURN 0
