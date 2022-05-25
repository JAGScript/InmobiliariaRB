CREATE PROCEDURE [dbo].[GuardarCanton]
	@i_id_provincia     INT,
    @i_cod_canton       VARCHAR(100),
    @i_nombre           VARCHAR(100),
    @i_estado           BIT
AS

INSERT INTO dbo.CANTON
(
    IDPROVINCIA,
    CODCANTON,
    NOMBRECANTON,
    ESTADOCANTON
)
VALUES
(
    @i_id_provincia,
    @i_cod_canton,
    @i_nombre,
    @i_estado
)

RETURN 0
