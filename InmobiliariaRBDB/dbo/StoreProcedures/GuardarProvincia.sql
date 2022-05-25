CREATE PROCEDURE [dbo].[GuardarProvincia]
	@i_cod_provincia    VARCHAR(100),
    @i_nombre           VARCHAR(100),
    @i_estado           BIT
AS

INSERT INTO dbo.PROVINCIA
(
    CODPROVINCIA,
    NOMBREPROVINCIA,
    ESTADOPROVINCIA
)
VALUES
(
    @i_cod_provincia,
    @i_nombre,
    @i_estado
)

RETURN 0
